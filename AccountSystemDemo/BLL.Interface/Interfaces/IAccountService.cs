using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(string owner, CardType type, IAccountNumberCreateService id);

        void DepositAccount(int id, int sum);

        void WithdrawAccount(int id, int sum);

        void CloseAcc(int id);

        void SaveToStorage();

        IEnumerable<Account> GetAllAccounts();
    }
}
