using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountNumberCreateService
    {
        int GenerateId(string name, string lastname, CardType type);
    }
}
