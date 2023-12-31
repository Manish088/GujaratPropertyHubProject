using PropertyEntity;

namespace PropertyAPI.IService
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<bool> IsEmailAvailable(string email);
        Task<(bool Result, PropertyEntity.User? User)> AuthenticationUser(string email, string password);
    }
}
