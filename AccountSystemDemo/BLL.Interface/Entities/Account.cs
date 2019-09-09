using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class Account
    {
        private int accountNumber;
        private int balance;


        public Account() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        public Account(int id, string owner, int balance, CardType cardType, double bonus)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = balance;
            Type = cardType;
            Bonus = bonus;
            Status = Status.Active;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        public Account(int id, string owner, CardType cardType)
        {
            AccountNumber = id;
            Owner = owner;
            Type = cardType;
            Status = Status.Active;
        }

        /// <summary>
        /// Id property
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Id cannot be negative");
                }

                accountNumber = value;
            }
        }

        /// <summary>
        /// Owner property
        /// </summary>
        public string Owner { get; private set; }

        public int Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value < 0)
                    throw new Exception("Balance cannot be negative");
                balance = value;
            }
        }

        /// <summary>
        /// Bonus property
        /// </summary>
        public double Bonus { get; private set; }

        /// <summary>
        /// Status property
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Type property
        /// </summary>
        public CardType Type { get; private set; }

        /// <summary>
        /// IsActive property
        /// </summary>
        bool IsActive { get { if (Status == Status.Active) return true; else return false; } }

        /// <summary>
        /// Add sum to account
        /// </summary>
        /// <param name="sum"></param>
        public void AddSum(int sum, IBonus bonusLogic)
        {
            if (sum < 0)
                throw new ArgumentException("Sum cannot be negative");

            if (IsActive)
            {
                Balance += sum;
                bonusLogic.Add(sum, Type);
            }
            else throw new Exception("Account closed");
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="sum"></param>
        public void WithdrawSum(int sum, IBonus bonusLogic)
        {
            if (sum < 0)
                throw new ArgumentException("Sum cannot be negative");

            if (IsActive)
            {
                if (Balance >= sum)
                {
                    Balance -= sum;
                    Bonus = bonusLogic.Withdraw(sum, Type) < Bonus ? Bonus - bonusLogic.Withdraw(sum, Type) : 0;
                }
                else throw new Exception("Account closed");
            }
        }

        /// <summary>
        /// Close account
        /// </summary>
        public void Close()
        {
            Status = Status.Closed;
        }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"{AccountNumber},{Owner}, {Balance}, {Type}");
        }
    }
}

