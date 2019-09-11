using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public string GenerateId(int id)
        {
            return id.ToString();
        }
    }
}