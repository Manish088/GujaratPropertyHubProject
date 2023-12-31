using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PropertyAPI.IRepository;
using PropertyEntity.Data;

namespace PropertyAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;   
        }
        public async Task<(bool Result, PropertyEntity.User? User)> AuthenticationUser(string email, string password)
        {
            try
            {
                var Result = false;
                PropertyEntity.User? user = null;

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    Result = await _applicationDbContext.user.AnyAsync(x => x.Email == email && x.Password == password);
                    if (Result)
                    {
                        user = await _applicationDbContext.user.FirstOrDefaultAsync(x => x.Email == email);
                    }
                }

                return (Result, user);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task CreateUser(PropertyEntity.User user)
        {
            try
            {
                if (user != null)
                {
                    user.CreatedBy= user.FirstName+" "+user.LastName;
                    user.CreatedDate= DateTime.Now;
                    _applicationDbContext.user.Add(user);
                    await _applicationDbContext.SaveChangesAsync();
            
                }

            }
            catch(Exception ex)
            {
                throw;
            }
            

        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            try
            {
                bool CheckEmail = false;
                if (string.IsNullOrEmpty(email))
                {
                    CheckEmail = await _applicationDbContext.user.AnyAsync(x => x.Email == email); 
                   return CheckEmail;

                }
                   return CheckEmail;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
