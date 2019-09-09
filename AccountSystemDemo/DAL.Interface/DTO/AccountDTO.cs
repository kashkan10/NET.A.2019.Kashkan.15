using System;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
        private int accountNumber;
        private int balance;

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
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        /// <param name="status"></param>
        public AccountDTO(int id, string name, string lastName, int balance, CardTypeDTO cardType, StatusDTO status, double bonus)
        {
            AccountNumber = id;
            Name = name;
            LastName = lastName;
            Balance = balance;
            Type = cardType;
            Status = status;
            Bonus = bonus;
        }

        /// <summary>
        /// AccountNumber property
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
                    throw new Exception("Id cannot be negative");
                accountNumber = value;
            }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// LastName property
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Balance property
        /// </summary>
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
            return (AccountNumber + Name + LastName).ToString().GetHashCode();
        }
    }
}
