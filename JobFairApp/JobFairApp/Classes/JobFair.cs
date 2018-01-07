using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobFairApp.Classes
{
    public class JobFair : ISQLObject<JobFair>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public int ContactPersonID { get; set; }

        public Person ContactPerson
        {
            get
            {
                return new Person().FromID(ContactPersonID);
            }
            set
            {
                ContactPersonID = value.ID;
            }
        }

        public JobFair FromID(int ID)
        {
            String query = "SELECT * FROM JobFairs WHERE ID = '" + ID + "'";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            
            reader.Read();

            FromDataReader(reader);

            connection.Close();

            return this;
        }

        public JobFair FromDataReader(SqlDataReader reader)
        {
            //just fill with default values if there's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                Title = "";
                Description = "";
                StartDate = DateTime.Today;
                EndDate = DateTime.Today;
                Website = null;
                Phone = null;
                ContactPersonID = MySQLUtils.NullID;
                

                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            Title = reader.GetString(reader.GetOrdinal("Title"));
            Description = reader.GetString(reader.GetOrdinal("Description"));
            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
            Website = reader.GetString(reader.GetOrdinal("Website"));
            Phone = reader.GetString(reader.GetOrdinal("Phone"));
            ContactPersonID = reader.GetInt32(reader.GetOrdinal("ContactPersonID"));

            return this;
        }

        public JobFair FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            Title = (string)row["Title"];
            Description = (string)row["Description"];
            StartDate = (DateTime)row["StartDate"];
            EndDate = (DateTime)row["EndDate"];
            Website = (string)row["Website"];
            Phone = (string)row["Phone"];
            ContactPersonID = (int)row["ContactPersonID"];
            
            return this;
        }

        public int Insert()
        {
            String statement;
            statement = "INSERT INTO JobFairs " +
                    "(Title, Description, StartDate, EndDate, " +
                    "Website, Phone, ContactPersonID) VALUES" +
                     "(" +
                     "'" + Title + "'," +
                     "'" + Description + "'," +
                     "'" + StartDate + "'," +
                     "'" + EndDate + "'," +
                     "'" + Website + "'," +
                     "'" + Phone + "'," +
                     "'" + ContactPersonID + "')" +
                     " SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            //downcast, then cast to int
            ID = (int)(decimal)command.ExecuteScalar();

            connection.Close();

            return ID;
        }

        public int Set()
        {
            String statement;
            statement = "UPDATE JobFairs SET " +
                    "Title = '" + Title + "' " +
                    "Description = '" + Description + "' " +
                    "StartDate = '" + StartDate + "' " +
                    "EndDate = '" + EndDate + "' " +
                    "Website = '" + Website + "' " +
                    "Phone = '" + Phone + "' " +
                    "ContactPersonID = '" + ContactPersonID + "'";


            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            int retValue = command.ExecuteNonQuery();

            connection.Close();

            return retValue;
        }
    }
}
