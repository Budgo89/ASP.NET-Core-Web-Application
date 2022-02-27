using BD.Models;
using BusinessLogic.Models;

namespace BusinessLogic.Mapers
{
    internal static class Maper
    {
        public static Accounts MapAccountsBLIsAccounts(AccountsBL accountsBl)
        {
            return new Accounts
            {
                Id = accountsBl.Id,
                UserId = accountsBl.UserId,
                Check = accountsBl.Check
            };
        }

        public static AccountsBL MapEmployeesIsAccounts(Employees employees)
        {
            return new AccountsBL
            {
                Id = employees.Id,
                UserId = employees.UserId,
                UserName = employees.Name
            };
        }
    }
}