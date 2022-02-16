using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Microsoft.Data.SqlClient;

namespace BD
{
    public static class ConnectHelper
    {
        private const string Connect =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDWebApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection ConnectionString()
        {
            //var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BDWebApi"].ConnectionString);
            var sqlConnection = new SqlConnection(Connect);
            return sqlConnection;
        }

    }
}
    

