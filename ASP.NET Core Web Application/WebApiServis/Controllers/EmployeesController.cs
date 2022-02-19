using System.Collections.Generic;
using System.Threading.Tasks;
using BD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiServis.Controllers
{
    [ApiController]
    [Authorize]
    [Route("controller/Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> iLogger)
        {
            _logger = iLogger;
        }

        [HttpGet("{id}")]
        public Task<Employees> GetEmployees([FromRoute] int id)
        {
            return null;
        }

        [HttpPost("Employees")]
        public Task<List<Employees>> PostEmployees([FromBody] Employees employees)
        {
            return null;
        }

        [HttpPut("Employees")]
        public Task PutEmployees([FromBody] Employees employees)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public Task DeleteEmployees([FromRoute] Employees employees)
        {
            return null;
        }
    }
}
