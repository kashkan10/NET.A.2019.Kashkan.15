using NUnit.Framework;
using Moq;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Tests
{
    class AccountServiceTests
    {
        [Test]
        public void CreateAccTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.CreateAccount("Don MOn", CardType.Base, idGen);
            repository.Verify(repo => repo.AddAccount(It.IsAny<AccountDTO>()));
        }

        [Test]
        public void DeleteAccTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.CreateAccount("Don MOn", CardType.Base, idGen);
            service.DeleteAccount(idGen.GenerateId("Don MOn", CardType.Base));
            repository.Verify(repo => repo.RemoveAccount(It.IsAny<AccountDTO>()));
        }

        [Test]
        public void GetAllAccsTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.GetAllAccounts();
            repository.Verify(repo => repo.GetAllAccounts());
        }
    }
}
