using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobFairApp.Classes
{
    public class Person : ISQLObject<Person>
    {
        public int ID { get; set; }
        public String First { get; set; }//15 chars
        public char MI { get; set; }
        public String Last { get; set; }//30 chars
        public int Title { get; set; }
        public String Address1 { get; set; }//25 chars
        public String Address2 { get; set; }//25 chars
        public String City { get; set; }//20 chars
        public String State { get; set; }//2 chars
        public String Zip { get; set; }//10 chars
        public String Email { get; set; }//35 chars
        public String Phone { get; set; }//13 chars

        public Person()
        {
            ID = MySQLUtils.NullID;
            //all other values already default to null
        }

        public String FullName
        {
            get
            {
                return First + " " + MI + ". " + Last;
            }
        }

        public bool IsCandidate()
        {
            String statement = "SELECT * FROM Candidates WHERE Candidates.PersonID = " + ID;

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);
            
            SqlDataReader reader = command.ExecuteReader();

            bool hasRows = reader.HasRows;

            connection.Close();

            return hasRows;
        }

        public Candidate GetCandidate()
        {
            String statement = "SELECT * FROM Candidates WHERE Candidates.PersonID = " + ID;

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            Candidate returner = new Candidate().FromDataReader(reader);

            connection.Close();

            return returner;
        }

        public bool IsInterviewer()
        {
            String statement = "SELECT * FROM Interviewers WHERE Interviewers.PersonID = " + ID;

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            bool hasRows = reader.HasRows;

            connection.Close();

            return hasRows;
        }

        public Interviewer GetInterviewer()
        {
            String statement = "SELECT * FROM Interviewers WHERE Interviewers.PersonID = " + ID;

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            Interviewer returner = new Interviewer().FromDataReader(reader);

            connection.Close();

            return returner;
        }

        public List<Interview> CandidateInterviews()
        {
            String statement = "SELECT * FROM Interviews, Candidates " +
                "WHERE Interviews.CandidateID = Candidates.ID AND" +
                      "Candidates.PersonID = " + ID + "";
            List<Interview> returner = new List<Interview>();

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            //read rows
            while (reader.Read())
            {
                returner.Add(new Interview().FromDataReader(reader));
            }

            connection.Close();

            return returner;
        }

        public List<Interview> InterviewerInterviews()
        {
            String statement = "SELECT * FROM Interviews, Interviewers, InterviewInterviewers " +
                "WHERE InterviewInterviewers.InterviewID = Interviews.ID AND" +
                      "Interviewers.PersonID = " + ID;
            List<Interview> returner = new List<Interview>();

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            //read rows
            while(reader.Read())
            {
                returner.Add(new Interview().FromDataReader(reader));
            }

            connection.Close();

            return returner;
        }

        public Person FromID(int ID)
        {
            String query = "SELECT * FROM People WHERE ID = '" + ID + "'";

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

        public Person FromDataReader(SqlDataReader reader)
        {
            //just fill with default values if there's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                First = null;
                MI = '\0';
                Last = null;
                Address1 = null;
                Address2 = null;
                City = null;
                State = null;
                Zip = null;
                Email = null;
                Phone = null;

                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            First = reader.GetString(reader.GetOrdinal("First"));
            MI = reader.GetString(reader.GetOrdinal("MI"))[0];
            Last = reader.GetString(reader.GetOrdinal("Last"));
            Address1 = reader.GetString(reader.GetOrdinal("Address1"));
            Address2 = reader.GetString(reader.GetOrdinal("Address2"));
            City = reader.GetString(reader.GetOrdinal("City"));
            State = reader.GetString(reader.GetOrdinal("State"));
            Zip = reader.GetString(reader.GetOrdinal("Zip"));
            Email = reader.GetString(reader.GetOrdinal("Email"));
            Phone = reader.GetString(reader.GetOrdinal("Phone"));

            return this;
        }

        public Person FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            First = (string)row["First"];
            MI = (char)row["MI"];
            Last = (string)row["Last"];
            Address1 = (string)row["Address1"];
            Address2 = (string)row["Address2"];
            City = (string)row["City"];
            State = (string)row["State"];
            Zip = (string)row["Zip"];
            Email = (string)row["Email"];
            Phone = (string)row["Phone"];

            return this;
        }

        public int Insert()
        {
            String statement;
            statement = "INSERT INTO People " +
                    "(First, MI, Last, Title, " +
                    "Address1, Address2, City, State, Zip, " +
                    "Email, Phone) VALUES" +
                     "(" +
                     "'" + First    + "'," +
                     "'" + MI       + "'," +
                     "'" + Last     + "'," +
                     "'" + Title    + "'," +
                     "'" + Address1 + "'," +
                     "'" + Address2 + "'," +
                     "'" + City     + "'," +
                     "'" + State    + "'," +
                     "'" + Zip      + "'," +
                     "'" + Email    + "'," +
                     "'" + Phone    + "')" +
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
            statement = "UPDATE People SET " +
                    "First = '" + First + "' " +
                    "MI = '" + MI + "' " +
                    "Last = '" + Last + "' " +
                    "Title = '" + Title + "' " +
                    "Address1 = '" + Address2 + "' " +
                    "Address2 = '" + Address1 + "' " +
                    "City = '" + City + "' " +
                    "State = '" + State + "' " +
                    "Zip = '" + Zip + "' " +
                    "Email = '" + Email + "' " +
                    "Phone = '" + Phone + "' " +
                    "WHERE ID = '" + ID + "'";



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
