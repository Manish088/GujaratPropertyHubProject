using Microsoft.AspNetCore.Mvc;
using PropertyEntity.ViewModel;
using PropertyMVC.HTTPAPI.AccountHTTPAPI;

namespace PropertyMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            var result= await _accountService.Login(model);
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
