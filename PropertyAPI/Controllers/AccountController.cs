using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PropertyAPI.IService;
using PropertyEntity;
using PropertyEntity.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public AccountController(IUserService _userService, IMapper _mapper, IConfiguration _config)
        {
            this._userService = _userService;
            this._mapper = _mapper;
            this._config = _config;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string email, string password)
        {

            var (result, user) = await _userService.AuthenticationUser(email, password);
            if (result)
            {
                var tokenString = 0;
                //var tokenString = GenerateJSONWebToken(user);
                return Ok(tokenString);
            }
            return Ok("Faild Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            var UserDto = _mapper.Map<User>(user);
            await _userService.CreateUser(UserDto);
            return Ok();
        }
        /*[NonAction]
        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                                    new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
    }
}
