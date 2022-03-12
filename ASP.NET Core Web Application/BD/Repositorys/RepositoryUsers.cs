using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Models;
using Microsoft.Data.SqlClient;

namespace BD.Repositorys
{
    public class RepositoryUsers
    {
        public const string SqlExpression = "INSERT INTO Users (IdUser, Username) VALUES(@IdUser, @Username)";
        public Task AddUsers(Users users)
        {
            var connect = ConnectHelper.ConnectionString();

            using (var sqlConnection = new SqlConnection(connect))
            {
                sqlConnection.Open();
                var commands = new SqlCommand(SqlExpression, sqlConnection);
                var id = new SqlParameter("@IdUser", users.Id);
                commands.Parameters.Add(id);
                var username = new SqlParameter("@Username", users.Username);
                commands.Parameters.Add(username);
                sqlConnection.Close();
            }
            return Task.CompletedTask;
        }
    }
}
