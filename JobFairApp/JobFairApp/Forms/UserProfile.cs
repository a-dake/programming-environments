using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobFairApp.Classes;

namespace JobFairApp.Forms
{
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
            LoadProfile(new Person().FromID(Context.Person));
        }

        public void LoadProfile(Person p)
        {
            nameLabel.Text = p.FullName;

            //load interviews
            bool isCandidate = p.IsCandidate();
            bool isInterviewer = p.IsInterviewer();

            if(isCandidate)
            {
                Candidate candidate = p.GetCandidate();
                //differentiate if user has multiple types of interviews
                if (isInterviewer)
                {
                    Label newLabel = new Label();
                    newLabel.AutoSize = true;
                    newLabel.Text = "Candidate: ";
                    //size is determined by text
                    //location is determined below by vertically arranging contents of interviewPanel
                    interviewPanel.Controls.Add(newLabel);
                }

                DataGridView grid = new DataGridView();
                
                grid.ColumnCount = 3;
                grid.Columns[0].Name = "Company";
                grid.Columns[1].Name = "Table";
                grid.Columns[2].Name = "Time";

                String statement = "SELECT Companies.Name, Interviews.TableID, TimeSlots.StartTime FROM Interviews, InterviewInterviewers, Interviewers, CompanyInterviewers, Companies, TimeSlots " +
                        "WHERE Interviews.CandidateID = " + candidate.ID + " " +
                        "AND Interviews.ID = InterviewInterviewers.InterviewID AND InterviewInterviewers.InterviewerID = Interviewers.ID AND Interviewers.ID = CompanyInterviewers.InterviewerID AND CompanyInterviewers.CompanyID = Companies.ID " +
                        "AND Interviews.TimeSlotID = TimeSlots.ID";

                SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(statement, connection);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    String[] row = new String[]{
                        reader.GetString(reader.GetOrdinal("Name")),
                        "" + reader.GetInt32(reader.GetOrdinal("TableID")),
                        "" + reader.GetTimeSpan(reader.GetOrdinal("StartTime")),
                    };
                    grid.Rows.Add(row);
                }
                connection.Close();

                interviewPanel.Controls.Add(grid);

                //have to resize after adding because the font size is set ny the container
                grid.AutoResizeColumnHeadersHeight();
            }
            if (isInterviewer)
            {
                Interviewer interviewer = p.GetInterviewer();
                //differentiate if user has multiple types of interviews
                if (isCandidate)
                {
                    Label newLabel = new Label();
                    newLabel.AutoSize = true;
                    newLabel.Text = "Interviewer: ";
                    //size is determined by text
                    //location is determined below by vertically arranging contents of interviewPanel
                    interviewPanel.Controls.Add(newLabel);
                }

                DataGridView grid = new DataGridView();
                grid.ColumnCount = 3;
                grid.Columns[0].Name = "Candidate";
                grid.Columns[1].Name = "Table";
                grid.Columns[2].Name = "Time";

                String statement = "SELECT People.First, Interviews.TableID, TimeSlots.StartTime FROM Interviews, InterviewInterviewers, Interviewers, Candidates, People, TimeSlots " +
                        "WHERE Interviewers.ID = " + interviewer.ID + " " +
                        "AND Interviews.ID = InterviewInterviewers.InterviewID AND InterviewInterviewers.InterviewerID = Interviewers.ID " +
                        "AND Interviews.CandidateID = Candidates.ID AND Candidates.PersonID = People.ID " +
                        "AND Interviews.TimeSlotID = TimeSlots.ID";

                SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(statement, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String[] row = new String[]{
                        reader.GetString(reader.GetOrdinal("First")),
                        "" + reader.GetInt32(reader.GetOrdinal("TableID")),
                        "" + reader.GetTimeSpan(reader.GetOrdinal("StartTime")),
                    };
                    grid.Rows.Add(row);
                }
                connection.Close();

                interviewPanel.Controls.Add(grid);

                //have to resize after adding because the font size is set ny the container
                grid.AutoResizeColumnHeadersHeight();
            }

            VerticallyArrangeContents(interviewPanel);
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            Form input = new Form();
            Label label = new Label();
            label.Text = "Please enter your user ID:";
            label.Dock = DockStyle.Top;
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Top;

            input.Controls.Add(label);
            input.Controls.Add(textBox);

            input.ShowDialog();

            Person p = new Person().FromID(int.Parse(textBox.Text));
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            //Form subForm = new Form();
            //PersonControl personControl = new PersonControl();
            //personControl.PersonValidated += delegate (object source, EventArgs args)
            //{
            //    subForm.DialogResult = DialogResult.OK;
            //    subForm.Hide();
            //};
            //personControl.Location = new Point(0,0);
            //subForm.Size = personControl.Size;
            //subForm.Controls.Add(personControl);


            //DialogResult result = subForm.ShowDialog();

            //if(result == DialogResult.OK)
            //{
            //    LoadProfile(personControl.Person);
            //}
        }

        #region Searching
        private void search()
        {
            SearchCompanyForm form = new SearchCompanyForm();
            form.FormClosing += delegate (object source, FormClosingEventArgs args)
            {
                Visible = true;
            };
            form.Show();
            form.SearchText = searchBox.Text;
            form.DoSearch();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
        #endregion

        private void VerticallyArrangeContents(Control container)
        {
            if (container.Controls.Count == 0) return;

            Control first = container.Controls[0];
            first.Location = new Point(2, 1);

            for (int i = 1; i < container.Controls.Count; i++)
            {
                Control c = container.Controls[i];
                int newX = 2;
                int newY = container.Controls[i - 1].Bottom + 1;
                c.Location = new Point(newX, newY);
            }
        }
    }//class(UserProfile)

    public class InterviewControl : UserControl
    {
        public Interview Interview
        {
            get
            {
                return null;
            }

            set
            {
                foreach (Interviewer interviewer in value.Interviewers())
                {

                }
            }
        }

        private TableLayoutPanel panel;
        private ListBox interviewersBox;
        private Label timeLabel;
        private Label tableLabel;

        public InterviewControl()
        {
            panel = new TableLayoutPanel();
            panel.RowCount = 1;
            panel.ColumnCount = 5;

            interviewersBox = new ListBox();
            timeLabel = new Label();
            tableLabel = new Label();
        }
        public InterviewControl(Interview interview) : this()
        {
            Interview = interview;
        }
    }
}//namespace
