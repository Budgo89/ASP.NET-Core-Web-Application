using BD;
using System;
using BD.Models;
using BD.Repositorys;
using BusinessLogic.Logics;
using Moq;
using Xunit;
using BusinessLogic.Models;

namespace TestLogic
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddAccounts()
        {
            Mock<RepositoryAccounts> repositoryAccounts = new Mock<RepositoryAccounts>();
            Mock<RepositoryEmployees> repositoryEmployees = new Mock<RepositoryEmployees>();
            
            Accounts accounast = new Accounts
            {
                Id = 1,
                UserId = 1,
                Check = 100
            };
            AccountsBL accounastBl = new AccountsBL
            {
                Id = 1,
                UserId = 1,
                Check = 100
            };

            Employees employees = new Employees
            {
                Id = 1,
                UserId = 1,
                Name = "sdfg"
            };

            repositoryAccounts.Setup(mock => mock.Add(accounast)).Returns(true);
            var accountsLogic = new AccountsLogic(repositoryEmployees.Object, repositoryAccounts.Object );
            
            accountsLogic.AddAccounts(accounastBl);
            repositoryAccounts.Verify(mock => mock.Add(accounast), Times.Once);
        }
    }
}
