using System;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int GenerateId(string name, string lastname, CardType type)
        {
            return Math.Abs((name + lastname + type.ToString()).GetHashCode());
        }
    }
}
