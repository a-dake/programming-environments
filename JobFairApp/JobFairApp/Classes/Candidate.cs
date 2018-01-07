using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public class Candidate : ISQLObject<Candidate>
    {
        public int ID { get; set; }
        public int PersonID { get; set; }

        public Candidate()
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

        public Candidate FromID(int ID)
        {
            String query = "SELECT * FROM Candidates WHERE ID = '" + ID + "'";

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

        public Candidate FromDataReader(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
            
            return this;
        }

        public Candidate FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            PersonID = (int)row["PersonID"];
            Person = null;//in case this was called on an existing object

            return this;
        }

        public int Insert()
        {
            if (PersonID == MySQLUtils.NullID) return MySQLUtils.NullID;

            String statement;
            statement = "INSERT INTO Candidates (PersonID) VALUES " +
                    "(" + PersonID + ")" +
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
            if (PersonID == MySQLUtils.NullID)
            {
                return 0;
            }

            String statement;
            statement = "UPDATE Candidates SET " +
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
    }//class(Candidate)
}//namespace