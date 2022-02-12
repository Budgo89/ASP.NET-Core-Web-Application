using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_API_servis.Models;

namespace Web_API_servis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsControllers : ControllerBase
    {
        private readonly ILogger<PersonsControllers> _logger;

        public PersonsControllers(ILogger<PersonsControllers> logger)
        {
            _logger = logger;
        }

        [HttpGet("persons/{id}")]
        public Task<Persons> GetPersonsId([FromRoute] int id)
        {
            return null;
        }

        [HttpGet("persons/search?searchTerm={term}")]
        public Task<Persons> GetPersonsName([FromRoute] string term)
        {
            return null;
        }

        [HttpGet("/persons/?skip={skip}&take={take} ")]
        public Task<List<Persons>> GetPersons([FromRoute] int skip, int take)
        {
            var list = new List<Persons>();
            return null;
        }

        [HttpPost("/{persons}")]
        public void PostAddPersons([FromRoute] Persons persons)
        {

        }

        [HttpPut("/{persons}")]
        public void PutUpdatePersons([FromRoute] Persons persons)
        {

        }

        [HttpDelete("/ /persons/{id}")]
        public void DeletePersons([FromRoute] int id)
        {

        }
    }
}
