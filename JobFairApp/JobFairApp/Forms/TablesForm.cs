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
    public partial class TablesForm : Form
    {
        public TablesForm()
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

        //Loads the Locations names into a drop down list
        private void LoadLocations()
        {
            string Sql = "SELECT Name FROM JobFair.dbo.Locations WHERE VenueID=" + GetID("Venues", "Name", "" + cbJobFairs.SelectedItem);
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbLocations.Items.Add(DR[0]);
            }
            conn.Close();
        }

        private int GetID(string table, string column, string item)
        {
            //Get the JobFairID
            //Gets the venue Id, Retterer said create method here
            int ID = 0;
            string Sql = "SELECT ID FROM JobFair.dbo." + table + " WHERE " + column + "='" + item + "'";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read(); // read first row
                ID = rd.GetInt32(0);
            }
            conn.Close();
            return ID;
        }

        private void cbJobFairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Makes sure the name isn't left blank
            if (cbJobFairs.SelectedItem.ToString() == "" || cbLocations.SelectedItem.ToString() == "")
            {
                MessageBox.Show("The Job Fair combo box or the Locations combo box was left empty.", "ERROR");
                return; //To avoid doing any other code
            }
            else
            {
                int jobFairID = GetID("Venues", "Name", "" + cbJobFairs.SelectedItem);
                int locationID = GetID("Locations", "Name", "" + cbLocations.SelectedItem);
                //Insertion Code
                SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                //Send the startTime and the startTime+length through to the TimeSlots table (also day and job fair)
                String statement = "INSERT INTO Tables (JobFairID, LocationID, Accessible, HasPower) VALUES" +
                    "('" + jobFairID + "'," + //JobFairID
                    "'" + locationID + "'," + //LocationID
                    "'" + checkAccessible.Checked + "'," + //Accessible T/F
                    "'" + checkPower.Checked + "')"; //HasPower T/F
                command.CommandText = statement;
                command.ExecuteNonQuery();
                connection.Close();
                this.Dispose(); //Disposes the form
                                //}
            }
        }
    }
}
