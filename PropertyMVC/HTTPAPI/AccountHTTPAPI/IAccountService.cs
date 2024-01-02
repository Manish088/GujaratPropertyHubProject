using PropertyEntity.ViewModel;

namespace PropertyMVC.HTTPAPI.AccountHTTPAPI
{
    public interface IAccountService
    {
        public Task<string> Login(LoginVM model);
    }
}
