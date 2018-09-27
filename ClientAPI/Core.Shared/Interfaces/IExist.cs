using System.Threading.Tasks;

namespace ClientAPI.Core.Shared.Interfaces
{
    public interface IExist
    {
        Task<bool> IsExist(object obj);
    }
}