using System.Collections.Generic;
using System.Threading.Tasks;
using BD.Models;
using BD.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiServis.Controllers
{
    [ApiController]
    [Route("controller/Users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly RepositoryUsers _repository;

        public UsersController(ILogger<UsersController> iLogger)
        {
            _logger = iLogger;
            _repository =  new RepositoryUsers();
        }

        [HttpGet("{Id}")]
        public Task<Users> GetEmployees([FromRoute] int id)
        {
            return null;
        }

        [HttpPost("Users")]
        public Task<List<Users>> PostEmployees([FromBody] Users users)
        {
            return null;
        }

        [HttpPut("Users")]
        public async Task PutEmployees([FromBody] Users users)
        {
            await _repository.AddUsers(users);
        }

        [HttpDelete("{Id}")]
        public Task DeleteEmployees([FromRoute] string id)
        {
            return null;
        }
    }
}
