using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFairApp.Classes
{
    public static class Context
    {
        //many of these may be useless for a lot of forms
        public static int JobFair = MySQLUtils.NullID;
        public static int Person = MySQLUtils.NullID;
        public static int Company = MySQLUtils.NullID;
    }
}