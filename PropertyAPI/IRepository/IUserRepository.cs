using PropertyEntity;

namespace PropertyAPI.IRepository
{
    public interface IUserRepository
    {

        Task CreateUser(User user);
        Task<bool> IsEmailAvailable(string email);
        Task<(bool Result, PropertyEntity.User? User)> AuthenticationUser(string email, string password);
    }
}
