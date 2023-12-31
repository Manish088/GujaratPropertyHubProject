using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.IService;
using PropertyEntity;
using PropertyEntity.DTO;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService _userService, IMapper _mapper)
        {
            this._userService = _userService;
            this._mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string email,string password)
        {

            var (result, user) = await _userService.AuthenticationUser(email, password);
            if(result)
            {

            return Ok("success Fully Login");
            }
            return Ok("Faild Login");
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            var UserDto=_mapper.Map<User>(user);
            await _userService.CreateUser(UserDto);
            return Ok();
        }
    }
}
