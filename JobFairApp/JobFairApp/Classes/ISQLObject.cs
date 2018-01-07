using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobFairApp.Classes
{
    public interface ISQLObject<E>
    {
        E FromID(int ID);
        E FromDataReader(SqlDataReader reader);
        E FromDataRow(DataRow row);
        int Insert();//change to insert? currently both change and insert, depending upon ID existing
        int Set();//change entry
    }
}
