using BD.Models;
using Microsoft.EntityFrameworkCore;

namespace BD.Repositorys
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectHelper.ConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employees>().Ignore(x => x.Id);
        }
    }
}
