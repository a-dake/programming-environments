using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JobFairApp.Classes
{
    public class MySQLUtils                     // This will make it a lot easier to switch between our connection strings while testing
                                                // If possible put your name after the last comment below to show who's database the app is currently using, thank you.

    {                                           // Kamren's String: Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JobFair;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                                                // Bo's String: Data Source=.\SQLEXPRESS;Initial Catalog=JobFair;Integrated Security=True
                                                // Anna's String: Insert your string when you get the chance
                                                // Hayden's String: Insert your string when you get the chance

        // Current String: Bo
        public const String ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=JobFair;Integrated Security=True";
        public const int NullID = -1;
    }
}
