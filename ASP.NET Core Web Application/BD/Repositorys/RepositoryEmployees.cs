using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BD.Repositorys
{
    
    public class RepositoryEmployees
    {
        private const string SqlExpressionAdd = "INSERT INTO Employees (UserId, Name) VALUES(@UserId, @Name)";
        private const string SqlExpressionSelectId = "SELECT * FROM Employees WHERE Id = @Id";

        public Task AddEmployees(Employees employees)
        {
            var connect = ConnectHelper.ConnectionString();

            using (var sqlConnection = new SqlConnection(connect))
            {
                sqlConnection.Open();
                var commands = new SqlCommand(SqlExpressionAdd, sqlConnection);
                var id = new SqlParameter("@IdUser", employees.UserId);
                commands.Parameters.Add(id);
                var username = new SqlParameter("@Name", employees.Name);
                commands.Parameters.Add(username);
                sqlConnection.Close();
            }
            return Task.CompletedTask;
        }

        public async Task<Employees> GetEmployees(int id)
        {
            var connect = ConnectHelper.ConnectionString();
            using (var sqlConnection = new SqlConnection(connect))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlExpressionSelectId, sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                //var a = cmd.ExecuteReader();
                SqlDataReader reader = cmd.ExecuteReader();
                sqlConnection.Close();
                var a = new Employees()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
                };

                return new Employees()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
                };
            }
            return null;
        }

        public Task<Employees> PostEmployees(string name)
        {
            return null;
        }

        public Task DeleteEmployees(int id)
        {
            return null;
        }
    }
}
