using BD.Models;
using BD.Repositorys;
using BusinessLogic.Mapers;
using BusinessLogic.Models;

namespace BusinessLogic.Logics
{
    public class AccountsLogic
    {
        private RepositoryEmployees _repositoryEmployees;
        private RepositoryAccounts _repositoryAccounts;

        public AccountsLogic()
        {
            _repositoryEmployees = new RepositoryEmployees();
            _repositoryAccounts = new RepositoryAccounts();
        }
        public bool AddAccounts(AccountsBL accountsBl)
        {
            var accounts = Maper.MapAccountsBLIsAccounts(GetEmployees(accountsBl));
            return _repositoryAccounts.Add(accounts);
        }

        private AccountsBL GetEmployees(AccountsBL accountsBl)
        {
            var employees = _repositoryEmployees.GetEmployeesUserid(accountsBl.UserId).Result;
            accountsBl.UserName = employees.Name;
            accountsBl.Id = employees.Id;
            return accountsBl;
        }

        public bool UpdateAccounts(string name, int check)
        {
            var employees = GetEmployees(name);
            var accountsBl = Maper.MapEmployeesIsAccounts(employees);
            accountsBl.Check = check;
            return _repositoryAccounts.PutAccounts(Maper.MapAccountsBLIsAccounts(accountsBl));
        }

        private Employees GetEmployees(string name)
        {
            return _repositoryEmployees.PostEmployees(name).Result;
        }
    }
}
