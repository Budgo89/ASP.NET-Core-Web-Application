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
        public Task AddUsers(Users users)
        {
            var connect = ConnectHelper.ConnectionString();
            connect.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO [Users] (IdUser, Username) VALUES (@IdUser, @Username) ", connect);

            command.Parameters.AddWithValue("IdUser", users.Id);
            command.Parameters.AddWithValue("Username", users.Username);
            connect.Close();
            return Task.CompletedTask;
        }
    }
}
