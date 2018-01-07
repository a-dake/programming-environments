using JobFairApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobFairApp.Forms
{
    public partial class CreateFair : Form
    {
        public CreateFair()
        {
            InitializeComponent();
            LoadVenueNames();
            LoadPeopleNames();
        }

        //Loads the Venue names into a drop down list
        private void LoadVenueNames()
        {
            string Sql = "SELECT Name FROM JobFair.dbo.Venues";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbVenueNames.Items.Add(DR[0]);

            }
            conn.Close();
        }

        //Loads the People names into a drop down list
        private void LoadPeopleNames()
        {
            cbPeopleNames.DisplayMember = "First";
            cbPeopleNames.ValueMember = "";

            string Sql = "SELECT * FROM JobFair.dbo.People";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbPeopleNames.Items.Add(new Person().FromDataReader(DR));
            }
            conn.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int jobFairID; //To get the job fair id later
            //Gets the start date
            string startDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            DateTime calcStartDate = Convert.ToDateTime(startDate); //To create the dates by allowing for days to be added
            //Gets the end date
            string endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");
            DateTime calcEndDate = Convert.ToDateTime(endDate);

            //calculate number of days between calcStartDate and calcEndDate
            //if(numDays < 100)
            //brackets around entire rest of this

            //Gets the venue Id, Retterer said create method here
            int venueID = 0;
            string Sql = "SELECT ID FROM JobFair.dbo.Venues WHERE Name='" + cbVenueNames.SelectedItem + "'";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read(); // read first row
                venueID = rd.GetInt32(0);
            }
            conn.Close();

            //Get the Person Id
            int personID = ((Person)cbPeopleNames.SelectedItem).ID;


            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            //Send the startTime and the startTime+length through to the TimeSlots table (also day and job fair)
            String statement = "INSERT INTO JobFairs (Title, Description, StartDate, EndDate, Website, Phone, ContactPersonID) VALUES" +
                "('" + tbTitle.Text + "'," + //Title
                "'" + tbDescription.Text + "'," + //Description
                "'" + startDate + "'," + //Start Date
                "'" + endDate + "'," + //End Date
                "'" + tbWebsite.Text + "'," + //Website
                "'" + tbPhoneNumber.Text + "'," + //Phone
                "'" + personID + "') SELECT SCOPE_IDENTITY()"; //ContactPersonID

            command.CommandText = statement;
            jobFairID = Convert.ToInt32(command.ExecuteScalar()); //Gets the most recent ID for the most recent job fair
            int loops = 1;
            while (calcStartDate != calcEndDate && loops <= 100)
            {
                calcStartDate = calcStartDate.AddDays(1);
                loops++;
            }
            if (loops > 100)
            {
                //Code here to remove the job fair and have the user try again to as the job fair was over one hundred days long
                statement = "DELETE FROM JobFairs WHERE ID=" +
                "('" + jobFairID + "')"; //JobFairID
                command.CommandText = statement;
                command.ExecuteNonQuery();
                connection.Close();
                //Message box for the user
                MessageBox.Show("Your job fair was either over 100 days long or the dates were incorrect, please try again.", "ERROR");
                return; //To avoid doing any other code
            }
            //Will loop for every day for as long as the job fair is (4 times for 4 days)
            while (loops > 0)
            {
                statement = "INSERT INTO JobFairDays(ID, JobFairID) VALUES" +
                "('" + loops + "'," + //DayID
                "'" + jobFairID + "')"; //JobFairID
                command.CommandText = statement;
                command.ExecuteNonQuery();
                loops--;
            }
            connection.Close();
            this.Dispose(); //Closes the window
        }
    }
}
