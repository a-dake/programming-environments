using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public class Location : ISQLObject<Location>
    {
        public int ID { get; set; }
        public int VenueID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public Location FromID(int ID)
        {
            String query = "SELECT * FROM Locations WHERE ID = '" + ID + "'";

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

        public Location FromDataReader(SqlDataReader reader)
        {
            //just fill with default values if there's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                VenueID = MySQLUtils.NullID;
                Name = null;
                Description = null;
                
                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            VenueID = reader.GetInt32(reader.GetOrdinal("VenueID"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
            Description = reader.GetString(reader.GetOrdinal("Description"));
            
            return this;
        }

        public Location FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            VenueID = (int)row["VenueID"];
            Name = (string)row["Name"];
            Description = (string)row["Description"];
            
            return this;
        }

        
        public int Insert()
        {
            String statement;
            statement = "INSERT INTO Locations " +
                    "(VenueID, Name, Description) VALUES" +
                     "(" +
                     "'" + VenueID + "'," +
                     "'" + Name + "'," +
                     "'" + Description + "')" +
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
            statement = "UPDATE Locations SET " +
                    "VenueID = '" + VenueID + "' " +
                    "Name = '" + Name + "' " +
                    "Description = '" + Description + "' " +
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
