using System.Collections.Generic;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private IRepository repo;
        private IBonus bonus;

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="idCreate"></param>
        /// <param name="bonus"></param>
        /// <param name="repo"></param>
        public AccountService(IRepository repo, IBonus bonus)
        {
            this.bonus = bonus;
            this.repo = repo;
        }

        /// <summary>
        /// Create new account 
        /// </summary>
        /// <param name="account"></param>
        public void CreateAccount(string owner, CardType type ,IAccountNumberCreateService id)
        {
            this.bonus = new BonusLogic();
            Account acc = new Account(id.GenerateId(owner, type), owner, type);
            repo.AddAccount(AccountMapper.mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAccount(int id)
        {
            Account acc = AccountMapper.mapper.Map<Account>(repo.GetAccount(id));
            repo.RemoveAccount(AccountMapper.mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Deposit sum to account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void DepositAccount(int id, int sum)
        {
            Account acc = AccountMapper.mapper.Map<Account>(repo.GetAccount(id));
            acc.AddSum(sum, bonus);
            repo.UpdateAccount(id, AccountMapper.mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void WithdrawAccount(int id, int sum)
        {
            Account acc = AccountMapper.mapper.Map<Account>(repo.GetAccount(id));
            acc.WithdrawSum(sum, bonus);
            repo.UpdateAccount(id, AccountMapper.mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="id"></param>
        public void CloseAcc(int id)
        {
            Account acc = AccountMapper.mapper.Map<Account>(repo.GetAccount(id));
            acc.Close();
            repo.UpdateAccount(id, AccountMapper.mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Write list to storage
        /// </summary>
        /// <param name="storage"></param>
        public void SaveToStorage()
        {
            repo.SaveToStorage();
        }

        /// <summary>
        /// Load List from storage
        /// </summary>
        /// <param name="storage"></param>
        public IEnumerable<Account> GetAllAccounts()
        {
            return AccountMapper.mapper.Map<IEnumerable<Account>>(repo.GetAllAccounts());
        }
    }
}
