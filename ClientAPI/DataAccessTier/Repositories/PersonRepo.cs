using System.Threading.Tasks;
using ClientAPI.DataAccessTier.Contracts.IRepositories;
using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClientAPI.DataAccessTier.Repositories
{
    public class PersonRepo : DataRepositoryBase<Person>, IPersonRepo
    {
        public async Task<Person> Login(string username, string password)
        {
            using (var dbContext = GetDbContextInstance())
            {
                var dbSet = dbContext.Set<Person>();
               
                if (dbSet == null)
                    return null;

                var user = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username);
                
                if(user == null)
                    return null;

                if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                return user;
            }
        }

        public async Task<Person> Register(Person user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password,out passwordHash,out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;        
            var newUser = await AddEntityAsync(user);
            if(newUser != null)
                return newUser;

            return null;
        }

        public async Task<bool> UserExist(string username)
        {
             var result = await AnyEntityAsync(e=>e.Username == username) ? true : false;
            
            return result;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {               
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    return false;
                }
            }

            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        protected override async Task<Person> GetEntityById(DataContext context, int id)
        {
    
            var dbSet = context.Set<Person>();
                if (dbSet == null)
                    return null;

            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.PersonId == id).ConfigureAwait(false);
        }
    }
}