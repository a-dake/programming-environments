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
    public partial class LocationsForm : Form
    {
        public LocationsForm()
        {
            InitializeComponent();
            LoadJobFairs();
        }

        //Loads the JobFair names into a drop down list
        private void LoadJobFairs()
        {
            string Sql = "SELECT Name FROM JobFair.dbo.Venues";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbJobFairs.Items.Add(DR[0]);
            }
            conn.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Makes sure the name isn't left blank
            if (tbName.Text == "" || cbJobFairs.SelectedItem.ToString()=="")
            {
                MessageBox.Show("Your Location was missing a name or a Job Fair was not selected.", "ERROR");
                return; //To avoid doing any other code
            }
            else
            {
                int venueID = GetVenueID();
                //Insertion Code
                SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                //Send the startTime and the startTime+length through to the TimeSlots table (also day and job fair)
                String statement = "INSERT INTO Locations (VenueID, Name, Description) VALUES " +
                    "('" + venueID + "'," +
                    "'" + tbName.Text + "'," +
                    "'" + descriptionBox.Text + "')";
                command.CommandText = statement;
                command.ExecuteNonQuery();
                connection.Close();
                this.Dispose(); //Disposes the form

                
            }
        }

        private int GetVenueID()
        {
            //Get the JobFairID
            //Gets the venue Id, Retterer said create method here
            int jobFairID = 0;
            string Sql = "SELECT ID FROM JobFair.dbo.Venues WHERE Name='" + cbJobFairs.SelectedItem + "'";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read(); // read first row
                jobFairID = rd.GetInt32(0);
            }
            conn.Close();
            return jobFairID;
        }
    }
}
