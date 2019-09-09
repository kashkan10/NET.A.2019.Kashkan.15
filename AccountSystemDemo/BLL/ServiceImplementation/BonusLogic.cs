using BLL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    public class BonusLogic : IBonus
    {
        /// <summary>
        /// Add bonus
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to add</returns>
        public double Add(int sum, CardType type)
        {
            return sum * (int)type / 100;
        }

        /// <summary>
        /// Withdraw bonus
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to withdraw</returns>
        public double Withdraw(int sum, CardType type)
        {
            return sum * (int)type / 200;
        }
    }
}