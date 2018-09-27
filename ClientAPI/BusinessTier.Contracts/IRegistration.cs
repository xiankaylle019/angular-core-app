using System.Threading.Tasks;
using ClientAPI.Core.Shared.Interfaces;
using ClientAPI.Shared.DTOs;
using ClientAPI.Shared.ViewModels;

namespace ClientAPI.BusinessTier.Contracts
{
    public interface IRegistration : IExist
    {
         /// <summary>
        /// Async register user service
        /// </summary>
        /// <param name="regUser"></param>
        /// <returns></returns>
        Task<PersonDTO> Register(PersonVM person);
    }
}