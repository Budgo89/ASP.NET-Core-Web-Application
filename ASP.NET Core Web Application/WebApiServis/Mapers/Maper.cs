using WebApiServis.Models;
using BusinessLogic.Models;

namespace WebApiServis.Mapers
{
    public static class Maper
    {
        public static AccountsBL MapAccountsInAccountsBd(Accounts accounts)
        {
            return new AccountsBL
            {
                UserId = accounts.UserId,
                Check = accounts.Check
            };
        }
    }
}
