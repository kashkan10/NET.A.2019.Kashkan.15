using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void AddAccount(AccountDTO account);

        void RemoveAccount(AccountDTO account);

        void UpdateAccount(int id, AccountDTO account);

        void SaveToStorage();

        void LoadFromStorage();

        AccountDTO GetAccount(int id);

        IEnumerable<AccountDTO> GetAllAccounts();
    }
}
