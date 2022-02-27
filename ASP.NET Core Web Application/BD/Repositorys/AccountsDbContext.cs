using BD.Models;
using Microsoft.EntityFrameworkCore;

namespace BD.Repositorys
{
    internal class AccountsDbContext : DbContext
    {

        public DbSet<Accounts> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectHelper.ConnectionString());
        }
    
    }
}