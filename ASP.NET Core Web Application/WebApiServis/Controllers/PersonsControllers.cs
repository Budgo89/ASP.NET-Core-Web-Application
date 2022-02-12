using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_API_servis.Models;
using WebApiServis.Logics;

namespace Web_API_servis.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PersonsControllers : ControllerBase
    {
        private readonly ILogger<PersonsControllers> _logger;
        private readonly PersonLogic _personLogic;

        public PersonsControllers(ILogger<PersonsControllers> logger, PersonLogic personLogic)
        {
            _logger = logger;
            _personLogic = personLogic;
        }

        [HttpGet("persons/{id}")]
        public Task<Person> GetPersonsId([FromRoute] int id)
        {
            return _personLogic.GetPersonsId(id);
        }

        [HttpGet("persons/search")]
        public Task<Person> FindPersonsName([FromQuery] string searchTerm)
        {
            return _personLogic.FindPersonsName(searchTerm);
        }

        [HttpGet("persons/")]
        public Task<List<Person>> FindPersons([FromQuery] int skip, [FromQuery] int take)
        {
            return _personLogic.FindPersons(skip, take);
        }

        [HttpPost("persons")]
        public async Task PostAddPersons([FromBody] Person persons)
        {
            await _personLogic.AddPersons(persons);
        }

        [HttpPut("persons")]
        public Task<string> PutUpdatePersons([FromBody] Person persons)
        {
            return _personLogic.UpdatePersons(persons);
        }

        [HttpDelete("persons/{id}")]
        public async Task DeletePersons([FromRoute] int id)
        {
            await _personLogic.DeletePersons(id);
        }
    }
}
