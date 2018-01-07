using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public class Table : ISQLObject<Table>
    {
        public int ID { get; set; }
        public int JobFairID;
        public int LocationID;
        public bool Accessible;
        public bool HasPower;

        public Table FromID(int ID)
        {
            String query = "SELECT * FROM Tables WHERE ID = '" + ID + "'";

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

        public Table FromDataReader(SqlDataReader reader)
        {
            //fill with default values if There's a problem
            if (!reader.HasRows)
            {
                ID = MySQLUtils.NullID;
                JobFairID = MySQLUtils.NullID;
                LocationID = MySQLUtils.NullID;
                Accessible = false;
                HasPower = false;

                return this;
            }

            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            JobFairID = reader.GetInt32(reader.GetOrdinal("JobFairID"));
            LocationID = reader.GetInt32(reader.GetOrdinal("LocationID"));
            Accessible = reader.GetBoolean(reader.GetOrdinal("Accessible"));
            HasPower = reader.GetBoolean(reader.GetOrdinal("HasPower"));

            return this;
        }

        public Table FromDataRow(DataRow row)
        {
            throw new NotImplementedException();
        }
        
        public int Insert()
        {
            String statement;
            statement = "INSERT INTO Tables (JobFairID, LocationID, Accessible, HasPower) VALUES" +
                "(" +
                "'" + JobFairID + "'," +
                "'" + LocationID + "'," +
                "'" + Accessible + "'," +
                "'" + HasPower + "')" +
                " SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            ID = (int)command.ExecuteScalar();

            connection.Close();

            return ID;
        }

        public int Set()
        {
            throw new NotImplementedException();
        }
    }//class(Table)
}//namespace
