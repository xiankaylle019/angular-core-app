using System.Threading.Tasks;
using ClientAPI.Shared.DTOs;
using ClientAPI.Shared.ViewModels;

namespace ClientAPI.BusinessTier.Contracts
{
    public interface IAuth
    {
        /// <summary>
        /// Async Login for user
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        Task<PersonDTO> Login (AuthVM auth);
    }
}