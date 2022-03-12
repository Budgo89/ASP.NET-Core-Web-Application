using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BD.Repositorys
{
    
    public class RepositoryEmployees : IRepositoryEmployees
    {

        private readonly EmployeesDbContext _context;

        public RepositoryEmployees()
        {
            _context = new EmployeesDbContext();
        }

        public async Task< bool> Add(Employees employees)
        {
            try
            {
                _context.Employees.Add(employees);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
        private bool Commit()
        {
            int count = _context.SaveChanges();

            return count > 0;
        }

        public Task<Employees> GetEmployees(int id)
        {
            try
            {
                var res = _context.Employees.Single(x => x.Id == id);
                return Task.FromResult(res);
            }
            catch (Exception e)
            {
                throw new Exception("Такого ID нет");
            }
        }

        public Task<Employees> PostEmployees(string name)
        {
            try
            {
                var res = _context.Employees.Single(x => x.Name == name);
                return Task.FromResult(res);
            }
            catch (Exception e)
            {
                throw new Exception("Такого имени нет");
            }
        }

        public async Task DeleteEmployees(int id)
        {
            try
            {
                var a = GetEmployees(id);
                _context.Employees.Remove(a.Result);
            }
            catch 
            {
                throw;
            }
        }
    }
}
