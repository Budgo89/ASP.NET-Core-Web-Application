using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Models;

namespace BD.Repositorys
{
    public class RepositoryAccounts : IRepository
    {
        private readonly AccountsDbContext _context;

        public RepositoryAccounts()
        {
            _context = new AccountsDbContext();
        }
        public bool Add(Accounts accounts)
        {
            try
            {
                _context.Accounts.Add(accounts);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool PutAccounts(Accounts account)
        {
            try
            {
                var accounts = GetAccounts(account.UserId).Result;
                accounts.Check = account.Check;
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new Exception("Пользователя нет");
            }
            return true;
        }

        public Task<Accounts> GetAccounts(int userId)
        {
            try
            {
                var res = _context.Accounts.Single(x => x.UserId == userId);
                return Task.FromResult(res);
            }
            catch (Exception e)
            {
                throw new Exception("Такого ID нет");
            }
        }
    }
}
