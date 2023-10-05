using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.Dapper範例
{
    public class DbHelper
    {
        public static string GetConnectionString() 
        {
            string? Dbconnstring = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            if (string.IsNullOrEmpty(Dbconnstring)) 
            {
                throw new Exception();
            }

            return Dbconnstring; 

        }

    }
}
