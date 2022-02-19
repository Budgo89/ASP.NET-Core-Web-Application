using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BD.Models;
using BD.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiServis.Controllers
{
    [ApiController]
    [Route("controller/Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly RepositoryEmployees _repositoryEmployees;

        public EmployeesController(ILogger<EmployeesController> iLogger)
        {
            _logger = iLogger;
            _repositoryEmployees = new RepositoryEmployees();
        }

        [HttpGet("{id}")]
        public Task<Employees> GetEmployees([Range(1, int.MaxValue)][FromRoute] int id)
        {
            return _repositoryEmployees.GetEmployees(id);
        }

        [HttpPost("{idUser}")]
        public Task<Employees> PostEmployees([Range(1, int.MaxValue)][FromRoute] int idUser)
        {
            return null;
        }

        [HttpPut("Employees")]
        public async Task<string> PutEmployees([FromBody] Employees employees)
        {
            await _repositoryEmployees.AddEmployees(employees);
            return "Ok";
        }

        [HttpDelete("{id}")]
        public Task DeleteEmployees([Range(1, int.MaxValue)][FromRoute] int id)
        {
            return null;
        }
    }
}
