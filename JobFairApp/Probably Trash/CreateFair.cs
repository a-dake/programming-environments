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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Gets the date
            string startDate = DateTimePicker.Value.ToString("yyyy-MM-dd");

            //Gets the venue Id

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

            //Does the insertion and gets the JobFair ID back
            int jobfairID;
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            //Send the startTime and the startTime+length through to the TimeSlots table (also day and job fair)
            String statement = "INSERT into JobFairs (Title, Description, StartDate, EndDate, VenueID, Website, Phone, ContactPersonID) VALUES" +
                "('" + tbTitle.Text + "'," +
                "'" + tbDescription.Text + "'," +
                "'" + startDate + "'," +
                "'" + null + "'," + //End Date
                "'" + venueID + "'," + //Venue ID
                "'" + null + "'," + //Website
                "'" + null + "'," + //Phone
                "'" + null + "'); SELECT jobfairID = SCOPE_IDENTITY()"; //ContactPersonID

            command.CommandText = statement;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
