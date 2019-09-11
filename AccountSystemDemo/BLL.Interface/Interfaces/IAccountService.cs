using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(string owner, CardType type, IAccountNumberCreateService id);

        void DepositAccount(string id, decimal sum);

        void WithdrawAccount(string id, decimal sum);

        IEnumerable<Account> GetAllAccounts();
    }
}