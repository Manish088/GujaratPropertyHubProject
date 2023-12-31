using PropertyAPI.IRepository;
using PropertyAPI.IService;
using PropertyEntity;

namespace PropertyAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<(bool Result, User? User)> AuthenticationUser(string email, string password)
        {
            return await _userRepository.AuthenticationUser(email, password);
        }

        public async Task CreateUser(User user)
        {
             await _userRepository.CreateUser(user);
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            return await _userRepository.IsEmailAvailable(email);
        }
    }
}
