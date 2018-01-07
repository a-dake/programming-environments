using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public class TimeSlot : ISQLObject<TimeSlot>
    {
        public int ID { get; set; }
        public int JobFairID { get; set; }
        public int CandidateID { get; set; }
        public int DayID { get; set; }
        //apparently there isn't a better class in C#... just treat this as "time since 12am"
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public TimeSlot FromID(int ID)
        {
            String query = "SELECT * FROM TimeSlots WHERE ID = '" + ID + "'";

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
        public TimeSlot FromDataReader(SqlDataReader reader)
        {
            //just fill with default values if there's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                JobFairID = MySQLUtils.NullID;
                DayID = MySQLUtils.NullID;
                StartTime = TimeSpan.Zero;
                EndTime = TimeSpan.Zero;

                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            JobFairID = reader.GetInt32(reader.GetOrdinal("JobFairID"));
            DayID = reader.GetInt32(reader.GetOrdinal("DayID"));
            StartTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime"));
            EndTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime"));
            
            return this;
        }

        public TimeSlot FromDataRow(DataRow row)
        {
            throw new NotImplementedException();
        }
        
        public int Insert()
        {
            String statement;
            statement = "INSERT INTO TimeSlots " +
                    "(JobFairID, DayID, StartTime, EndTime) VALUES" +
                     "(" +
                     "'" + JobFairID + "'," +
                     "'" + DayID + "'," +
                     "'" + StartTime + "'," +
                     "'" + EndTime + "')" +
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
            statement = "UPDATE TimeSlots SET " +
                    "JobFairID = '" + JobFairID + "' " +
                    "DayID = '" + DayID + "' " +
                    "StartTime = '" + StartTime + "' " +
                    "EndTime = '" + EndTime + "' " +
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
