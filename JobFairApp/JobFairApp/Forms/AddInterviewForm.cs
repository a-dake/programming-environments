using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobFairApp.Classes;
using System.Data.SqlClient;

namespace JobFairApp.Forms
{
    public partial class AddInterviewForm : Form
    {
        //used to select a random interviewer and table once all available ones are found
        Random rand = new Random();

        public AddInterviewForm()
        {
            InitializeComponent();

            m_lbl_CompanyName.Text = new Company().FromID(Context.Company).name;
            m_lbl_JobFair.Text = new JobFair().FromID(Context.JobFair).Title;

            LoadTimeSlots();
        }

        private void LoadTimeSlots()
        {
            //Here's an easier approach SQL-wise ... very inefficient though,
            //this will make seperate calls to the databse for EVERY INTERVIEW IN THIS FAIR

            //number of interviewers with this company
            int numInterviewers = 0;
            //all timeslots for this job fair
            List<TimeSlot> timeSlots = new List<TimeSlot>();

            String statement = "SELECT COUNT(*) FROM (SELECT Interviewers.ID FROM Companies, Interviewers, CompanyInterviewers " +
                            "WHERE Companies.ID = CompanyInterviewers.CompanyID AND Interviewers.ID = CompanyInterviewers.InterviewerID AND Companies.ID = " + Context.Company + ") AS ThisCompanyInterviewers";
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            numInterviewers = (int)command.ExecuteScalar();

            command.CommandText = "SELECT * FROM TimeSlots WHERE JobFairID = " + Context.JobFair;

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                timeSlots.Add(new TimeSlot().FromDataReader(reader));
            }

            reader.Close();

            foreach(TimeSlot t in timeSlots)
            {
                command.CommandText = "SELECT COUNT(*) FROM (SELECT Interviews.* FROM Companies, CompanyInterviewers, Interviewers, InterviewInterviewers, Interviews " +
                    "WHERE Companies.ID = CompanyInterviewers.CompanyID AND CompanyInterviewers.InterviewerID = Interviewers.ID " +
                    "AND Interviewers.ID = InterviewInterviewers.InterviewerID AND InterviewInterviewers.InterviewID = Interviews.ID " +
                    "AND Interviews.TimeSlotID = " + t.ID + " AND Companies.ID = " + Context.Company + ") AS ThisCompanyThisTimeSlotInterviews";

                //this is all interviews with the current company during the time slot
                int numInterviews = (int)command.ExecuteScalar();

                //the company has at least one interviewer availabe for that time slot
                if(numInterviews < numInterviewers)
                {
                    m_cb_TimeSlots.Items.Add(t);
                }
            }
            ////this finds all timeslots where the company does not have an interview during - not quite what we need!
            ////find all interviewers in the selected company
            ////find all interviews with current company's interviewers
            ////find all timeslots whose ID is not found in the timeslotID column of this company's interviews
            
            ////this is gonna be some complex-ass SQL
            //String statement;
            //statement = 
            //    "SELECT * FROM TimeSlots as ThisTimeSlot WHERE SELECT COUNT ( " +
            //        "SELECT TimeSlotID FROM " +
            //            "(SELECT Interviews.*, ThisCompanyInterviewers.* FROM " +
            //                "(SELECT Interviewers.* FROM Companies, Interviewers, CompanyInterviewers " +
            //                "WHERE Companies.ID = CompanyInterviewers.ID AND Interviewers.ID = CompanyInterviewers.ID AND Companies.ID = " + Context.Company + ") AS ThisCompanyInterviewers, Interviews, InterviewInterviewers, " +
            //            "WHERE ThisCompanyInterviewers.ID = InterviewInterviewers.InterviewerID AND Interviews.ID = InterviewInterviewers.InterviewID AND TimeSlotID = ThisTimeSlot.ID) AS ThisCompanyInterviews) > 0";

            //statement = "SELECT * FROM TimeSlots WHERE (SELECT COUNT(*) FROM TimeSlots) > 0";

            //SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            //connection.Open();

            //SqlCommand command = new SqlCommand(statement, connection);

            //SqlDataReader reader = command.ExecuteReader();

            //while(reader.Read())
            //{
            //   // m_cb_TimeSlots.Items.Add(new TimeSlot().FromDataReader(reader));
            //}
            
        }

        private void m_btn_Submit_Click(object sender, EventArgs e)
        {
            TimeSlot timeSlot = (TimeSlot)m_cb_TimeSlots.SelectedItem;

            Person person = new Person().FromID(Context.Person);

            Candidate candidate = null;
            if(person.IsCandidate())
            {
                candidate = person.GetCandidate();
            }
            else
            {
                MessageBox.Show("You cannot sign up for interviews as you are not a registerd candidate.");
                Dispose();
                return;
            }

            Interviewer interviewer = GetAvailableInterviewer(timeSlot);
            Table table = GetAvailableTable(timeSlot);

            Interview i = new Interview();
            i.JobFairID = Context.JobFair;
            i.CandidateID = candidate.ID;
            i.TimeSlotID = timeSlot.ID;
            i.TableID = table.ID;

            i.Insert();

            i.AddInterviewer(interviewer);

            MessageBox.Show("Your interview with " + m_lbl_CompanyName.Text + " at " + timeSlot.StartTime + " has been registered.");
            Dispose();
        }

        private Interviewer GetAvailableInterviewer(TimeSlot t)
        {
            //find available interviewers
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            //find the company's interviewers, then find all interviewers for all interviews happening during this time slot.
            //and interviewers who do not have an interview during this time slot will not be in the second list
            //command.CommandText = 
            //    "CREATE VIEW ThisCompanyInterviewers AS (SELECT Interviewers.* FROM Companies, CompanyInterviewers, Interviewers " +
            //        "WHERE Companies.ID = CompanyInterviewers.CompanyID AND CompanyInterviewers.InterviewerID = Interviewers.ID ); " +
            //    "CREATE VIEW ThisTimeSlotInterviewInterviewers AS (SELECT InterviewerInterviews.InterviewerID FROM InterviewInterviewers, Interviews " +
            //        "WHERE InterviewInterviewers.InterviewID = Interviews.ID AND Interviews.TimeSlotID = " + t.ID + ");" +
            //    "SELECT ThisCompanyInterviewers.* FROM " +
            //        "ThisCompanyInterviewers , " +
            //        "WHERE ThisCompanyInterviewers.ID NOT IN ThisTimeSlotInterviewsInterviewers";

            command.CommandText = "SELECT * FROM " +
                    "(SELECT Interviewers.* FROM Companies, CompanyInterviewers, Interviewers " +
                    "WHERE Companies.ID = CompanyInterviewers.CompanyID AND CompanyInterviewers.InterviewerID = Interviewers.ID AND Companies.ID = " + Context.Company + ") AS ThisCompanyInterviewers " +
                    "WHERE ID NOT IN " +
                    "(SELECT InterviewInterviewers.InterviewerID FROM InterviewInterviewers, Interviews " +
                    "WHERE InterviewInterviewers.InterviewID = Interviews.ID AND Interviews.TimeSlotID = " + t.ID + ")";
            List <Interviewer> availableInterviewers = new List<Interviewer>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                availableInterviewers.Add(new Interviewer().FromDataReader(reader));
            }

            //if you were to account for the last interviewer being assigned while window was open, you would do it here

            //choose a random interviewer
            int index = rand.Next(availableInterviewers.Count);

            return availableInterviewers[index];
        }

        private Table GetAvailableTable(TimeSlot t)
        {
            //find available tables
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            //find the company's interviewers, then find all interviewers for all interviews happening during this time slot.
            //and interviewers who do not have an interview during this time slot will not be in the second list
            command.CommandText = "SELECT Tables.* FROM Tables " +
                "WHERE Tables.ID NOT IN " +
                "(SELECT TableID FROM Interviews WHERE TimeSlotID = " + t.ID + ")";

            List<Table> availableTables = new List<Table>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                availableTables.Add(new Table().FromDataReader(reader));
            }

            //if you were to account for the last table being filled while window was open, you would do it here

            //choose a random table
            int index = rand.Next(availableTables.Count);

            return availableTables[index];
        }
    }//class(AddInterviewForm)
}//namespace
