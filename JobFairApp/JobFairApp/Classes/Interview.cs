using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public class Interview : ISQLObject<Interview>
    {
        public int ID { get; set; }
        public int JobFairID { get; set; }
        public int CandidateID { get; set; }
        public int TimeSlotID { get; set; }
        public int TableID { get; set; }

        public List<Interviewer> Interviewers()
        {
            String statement = "SELECT * FROM Interviewers, InterviewInterviewers WHERE InterviewInterviewers.InterviewerID = Interviewers.ID AND Interviewers.InterviewID = " + ID;

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Interviewer> returner = new List<Interviewer>();

            while (reader.Read())
            {
                returner.Add(new Interviewer().FromDataReader(reader));
            }

            return returner;
        }

        public void AddInterviewer(Interviewer interviewer)
        {
            String statement = "INSERT INTO InterviewInterviewers (InterviewID, InterviewerID) " +
                "VALUES (" + ID + ", " + interviewer.ID + ")";
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);
            int retValue = command.ExecuteNonQuery();
        }

        public void RemoveInterviewer(Interviewer interviewer)
        {
            String statement = "DELETE FROM InterviewInterviewers" +
                "WHERE InterviewerID = " + interviewer.ID + " AND InterviewID = " + ID;
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(statement, connection);
            int retValue = command.ExecuteNonQuery();
        }

        public Interview FromID(int ID)
        {
            String query = "SELECT * FROM Interviews WHERE ID = '" + ID + "'";

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

        public Interview FromDataReader(SqlDataReader reader)
        {
            //fill with default values if There's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                JobFairID = MySQLUtils.NullID;
                CandidateID = MySQLUtils.NullID;
                TimeSlotID = MySQLUtils.NullID;
                TableID = MySQLUtils.NullID;

                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            JobFairID = reader.GetInt32(reader.GetOrdinal("JobFairID"));
            CandidateID = reader.GetInt32(reader.GetOrdinal("CandidateID"));
            TimeSlotID = reader.GetInt32(reader.GetOrdinal("TimeSlotID"));
            TableID = reader.GetInt32(reader.GetOrdinal("TableID"));

            return this;
        }

        public Interview FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            JobFairID = (int)row["JobFairID"];
            CandidateID = (int)row["CandidateID"];
            TimeSlotID = (int)row["TimeSlotID"];
            TableID = (int)row["TableID"];
            
            return this;
        }

        public int Insert()
        {
            String statement;
            statement = "INSERT INTO Interviews (JobFairID, CandidateID, TimeSlotID, TableID) VALUES" +
                "(" +
                "'" + JobFairID + "'," +
                "'" + CandidateID + "'," +
                "'" + TimeSlotID + "'," +
                "'" + TableID + "')" +
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
            if (ID == MySQLUtils.NullID) return 0;
            
            String statement;
            statement = "UPDATE Interviews SET " +
                    "JobFairID = '" + JobFairID + "' " + 
                    "CandidateID = '" + CandidateID + "' " +
                    "TimeSLotID = '" + TimeSlotID + "' " +
                    "TableID = '" + TableID + "' " +
                    "WHERE ID = '" + ID + "'";


            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;

            int retValue = command.ExecuteNonQuery();

            connection.Close();

            return retValue;
        }
    }
}