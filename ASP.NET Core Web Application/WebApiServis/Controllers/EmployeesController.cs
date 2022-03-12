using System.Collections.Generic;
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

        public EmployeesController(ILogger<EmployeesController> iLogger, RepositoryEmployees repositoryEmployees)
        {
            _logger = iLogger;
            _repositoryEmployees = repositoryEmployees;
        }
        
        [HttpGet("{id}")]
        public Task<Employees> GetEmployees([FromRoute] int id)
        {
            return _repositoryEmployees.GetEmployees(id);
        }

        [HttpPost("{name}")]
        public Task<Employees> PostEmployees([FromRoute] string name)
        {
            return _repositoryEmployees.PostEmployees(name);
        }

        [HttpPut("Employees")]
        public async Task<bool> PutEmployees([FromBody] Employees employees)
        {
            return await _repositoryEmployees.Add(employees);
        }

        [HttpDelete("{id}")]
        public Task DeleteEmployees([FromRoute] int id)
        {
            _repositoryEmployees.DeleteEmployees(id);
            return null;
        }
    }
}
