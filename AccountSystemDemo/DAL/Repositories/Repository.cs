using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.IO;

namespace DAL.Repositories
{
    public class Repository : IRepository
    {
        List<AccountDTO> list;
        string Path;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Repository()
        {
            Path = "accounts.dat";
            list = new List<AccountDTO>();
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="path"></param>
        public Repository(string path)
        {
            Path = path;
            list = new List<AccountDTO>();
        }

        /// <summary>
        /// Add account to list
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(AccountDTO account)
        {
            if (list.Contains(account))
            {
                throw new Exception("Account is already exist");
            }

            list.Add(account);
        }

        /// <summary>
        /// Get account from list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public AccountDTO GetAccount(int id)
        {
            if (list.Contains(list.Find(acc => acc.AccountNumber == id)))
            {
                return list.Find(acc => acc.AccountNumber == id);
            }
            else
            {
                throw new Exception("Account not found");
            }
        }

        /// <summary>
        /// Remove account from list
        /// </summary>
        /// <param name="account"></param>
        public void RemoveAccount(AccountDTO account)
        {
            if (!list.Contains(account))
            {
                throw new Exception("Account not found");
            }

            list.Remove(account);
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        public void UpdateAccount(int id, AccountDTO account)
        {
            if (!list.Contains(list.Find(acc => acc.AccountNumber == id)))
            {
                throw new Exception("Account not found");
            }

            RemoveAccount(list.Find(accc => accc.AccountNumber == id));
            list.Add(account);
        }

        public void SaveToStorage()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (AccountDTO s in list)
                {
                    writer.Write(s.AccountNumber);
                    writer.Write(s.Name);
                    writer.Write(s.LastName);
                    writer.Write(s.Balance);
                    writer.Write((int)s.Type);
                    writer.Write((int)s.Status);
                    writer.Write(s.Bonus);
                }
            }
        }

        public void LoadFromStorage()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string name = reader.ReadString();
                    string lastName = reader.ReadString();
                    int balance = reader.ReadInt32();
                    CardTypeDTO type = (CardTypeDTO)reader.ReadInt32();
                    StatusDTO status = (StatusDTO)reader.ReadInt32();
                    double bonus = reader.ReadDouble();

                    list.Add(new AccountDTO(id, name, lastName, balance, type, status, bonus));
                }
            }
        }

        /// <summary>
        /// Get list of all accounts
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            return list;
        }
    }
}
