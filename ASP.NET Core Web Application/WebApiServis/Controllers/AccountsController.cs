using System.Threading.Tasks;
using BusinessLogic.Logics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiServis.Models;

namespace WebApiServis.Controllers
{
    [ApiController]
    [Route("controller/accounts")]
    public class AccountsController
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly AccountsLogic _accountsLogic;

        public AccountsController(ILogger<EmployeesController> iLogger)
        {
            _logger = iLogger;
            _accountsLogic = new AccountsLogic();
        }

        [HttpPut("create/accounts")]
        public async Task<bool> PutAccounts([FromBody] Accounts accounts)
        {
            return _accountsLogic.AddAccounts(Mapers.Maper.MapAccountsInAccountsBd(accounts));
        }

        [HttpPut("accounts")]
        public async Task<bool> PutCheck([FromQuery] string name, [FromQuery] int check)
        {
            return _accountsLogic.UpdateAccounts(name, check);
        }
    }
}
