using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll.Services
{
    public class SqlHelper
    {
        //this field gets initialized at Startup.cs
        public static string conStr;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conStr);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
