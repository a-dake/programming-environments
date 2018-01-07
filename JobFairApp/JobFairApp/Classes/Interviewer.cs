using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobFairApp.Classes
{
    public class Interviewer : ISQLObject<Interviewer>
    {
        public int ID { get; set; }
        public int PersonID { get; set; }

        public Interviewer()
        {
            ID = MySQLUtils.NullID;
            PersonID = MySQLUtils.NullID;
        }

        public Person Person
        {
            get
            {
                if (PersonID != MySQLUtils.NullID)
                {
                    return new Person().FromID(PersonID);
                }
                else throw new InvalidOperationException("No PersonID found!");
            }
            set
            {
                PersonID = value.ID;
            }
        }

        public Interviewer FromID(int ID)
        {
            String query = "SELECT * FROM Interviewers WHERE ID = '" + ID + "'";

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

        public Interviewer FromDataReader(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
            
            return this;
        }

        public Interviewer FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            PersonID = (int)row["PersonID"];
            
            return this;
        }

        public int Insert()
        {
            if (PersonID == MySQLUtils.NullID)return 0;

            String statement;
            statement = "INSERT INTO Interviewers (PersonID) VALUES" +
                "(" +
                "'" + PersonID + "')" +
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
            if (PersonID == MySQLUtils.NullID) return 0;
            
            String statement;
            statement = "UPDATE Interviewers SET " +
                    "PersonID = '" + PersonID + "' " +
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