using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountNumberCreateService
    {
        int GenerateId(string owner, CardType type);
    }
}
