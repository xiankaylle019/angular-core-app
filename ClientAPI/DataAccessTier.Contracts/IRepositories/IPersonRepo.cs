using System.Threading.Tasks;
using ClientAPI.Data.Core;
using ClientAPI.Models;

namespace ClientAPI.DataAccessTier.Contracts.IRepositories
{
    public interface IPersonRepo : IDataRepository<Person>
    {
        /// <summary>
        /// Async user login method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Person> Login (string username, string password);

        /// <summary>
        /// Async user registration method
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Person> Register(Person user, string password);

        /// <summary>
        /// Validates if user is already exist.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> UserExist(string username);
    }
}