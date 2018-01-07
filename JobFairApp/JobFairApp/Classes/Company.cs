using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;

namespace JobFairApp.Classes
{
    public class Company : ISQLObject<Company>
    {
        public int ID { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String description { get; set; }

        public Company()
        {
            ID = MySQLUtils.NullID;
            //all other values default to null, which is what they already default to
        }
        
        public Company FromID(int ID)
        {
            String query = "SELECT * FROM Companies WHERE ID = '" + ID + "'";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            SqlDataReader reader = cmd.ExecuteReader();
            
            reader.Read();

            FromDataReader(reader);

            connection.Close();

            return this;
        }
        public Company FromDataReader(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            name = reader.GetString(reader.GetOrdinal("Name"));
            description = reader.GetString(reader.GetOrdinal("Description"));
            phone = reader.GetString(reader.GetOrdinal("Phone"));
            email = reader.GetString(reader.GetOrdinal("Email"));

            
            return this;
        }

        public Company FromDataRow(DataRow row)
        {
            ID = (int)row["ID"];
            name = (String)row["Name"];
            email = (String)row["Email"];
            phone = (String)row["Phone"];
            description = (String)row["Description"];


            return this;
        }

        public int Insert()
        { 
            // Why does Companies have brackets, but Person.class doesnt? - Kamren
            // IS FAILING BECAUSE ITS NOT RETAINING AN ID, ITS RETURNING NULL BECAUSE WHEN WE INSERT OUR DATA FOR THE COMPANY IT DOESNT SET AN ID, SO IT CRASHES REEEEEEEEEEEEEEEE; Atleast I think so. - Kamren
            String statement = "INSERT INTO [Companies] (Name, Description, Phone, Email) VALUES" +
                    "(" +
                    "'" + name + "'," +
                    "'" + description + "'," +
                    "'" + phone + "', " +
                    "'" + email + "')" +
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
            statement = "UPDATE Companies SET " +
                    "Name = '" + name + "'" +
                    " Description = '" + description + "'" +
                    " Phone = '" + phone + "'" +
                    " Email = '" + email + "'";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.CommandType = CommandType.Text;

            int retValue = command.ExecuteNonQuery();

            connection.Close();

            return retValue;
        }

        public List<String> GetInterests()
        {
            if (ID == MySQLUtils.NullID) return null;

            String statement;
            statement = "SELECT Specialties.Name FROM CompanyInterests, Specialties " +
                "WHERE CompanyInterests.CompanyID = '" + ID + "' AND CompanyInterests.InterestID = Specialties.ID";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = statement;
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader();

            List<String> returner = new List<String>();

            while (reader.Read())
            {
                returner.Add((String)reader[0]);
            }

            connection.Close();

            return returner;
        }
    }
}