using System;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
        private decimal balance;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountDTO()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="bonus"></param>
        /// <param name="cardType"></param>
        public AccountDTO(string id, string owner, decimal balance, int bonus, CardTypeDTO cardType)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = balance;
            Type = cardType;
            Bonus = bonus;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        /// <param name="status"></param>
        /// <param name="bonus"
        public AccountDTO(string id, string owner, decimal balance, CardTypeDTO cardType, StatusDTO status, int bonus)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = balance;
            Type = cardType;
            Status = status;
            Bonus = bonus;
        }

        /// <summary>
        /// AccountNumber property
        /// </summary>
        public string AccountNumber { get; private set; }

        /// <summary>
        /// Owner property
        /// </summary>
        public string Owner { get; private set; }

        /// <summary>
        /// Balance property
        /// </summary>
        public decimal Balance
        {
            get
            {
                return balance;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Balance cannot be negative");
                }

                balance = value;
            }
        }

        /// <summary>
        /// Bonus property
        /// </summary>
        public int Bonus { get; private set; }

        /// <summary>
        /// Status property
        /// </summary>
        public StatusDTO Status { get; private set; }

        /// <summary>
        /// Type property
        /// </summary>
        public CardTypeDTO Type { get; private set; }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String representation</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            AccountDTO acc = obj as AccountDTO;

            if (acc == null)
            {
                return false;
            }

            return this.AccountNumber == acc.AccountNumber;
        }

        /// <summary>
        /// Override of GetHashCode() method
        /// </summary>
        /// <returns>integer number</returns>
        public override int GetHashCode()
        {
            return (AccountNumber + Owner).ToString().GetHashCode();
        }
    }
}