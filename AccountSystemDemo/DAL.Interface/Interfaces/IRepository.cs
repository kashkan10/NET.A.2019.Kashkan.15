using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void Create(AccountDTO account);

        void Update(AccountDTO account);

        AccountDTO GetByNumber(string id);

        IEnumerable<AccountDTO> GetAllAccounts();
    }
}