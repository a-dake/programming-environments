using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace JobFairApp.Classes
{
    public class Venue : ISQLObject<Venue>
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String LongDescription { get; set; }

        public Venue()
        {
            ID = MySQLUtils.NullID;
            //all other values already default to null
        }

        public Venue FromID(int ID)
        {
            String query = "SELECT * FROM Venues WHERE ID = '" + ID + "'";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            SqlDataReader reader = cmd.ExecuteReader();
            connection.Close();

            reader.Read();
            
            return FromDataReader(reader);
        }

        public Venue FromDataReader(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
            ShortDescription = reader.GetString(reader.GetOrdinal("[Short Description]"));
            LongDescription = reader.GetString(reader.GetOrdinal("[Long Description]"));

            
            return this;
        }

        public Venue FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            Name = (String)row["Name"];
            ShortDescription = (String)row["[Short Description]"];
            LongDescription = (String)row["[Long Description]"];

            return this;
        }

        public int Insert()
        {
            String statement = 
                "INSERT INTO Venues (Name, [Short Description], [Long Description]) VALUES" +
                "(" +
                "'" + Name + "'," +
                "'" + ShortDescription + "'," +
                "'" + LongDescription + "')";
            

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

        public int Set()
        {
            if (ID == MySQLUtils.NullID) return 0;

            String statement;
            statement = "UPDATE Venues SET " +
                    "Name = '" + Name + "'" +
                    " [Short Description] = '" + ShortDescription + "'" +
                    " [Long Description] = '" + LongDescription + "'" +
                    "WHERE ID = " + ID;
            
            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;

            int retValue = command.ExecuteNonQuery();

            connection.Close();

            return retValue;
        }
    }//class(Venue)
}//namespace
