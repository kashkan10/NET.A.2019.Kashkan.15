using System;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int GenerateId(string owner, CardType type)
        {
            return Math.Abs((owner + type.ToString()).GetHashCode());
        }
    }
}
