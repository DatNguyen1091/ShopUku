using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopUku_BAL.Services;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _usersService;
        private readonly AppSettings _appSettings;
        public UsersController(UserService usersService, IOptionsMonitor<AppSettings>
            optionsMonitor)
        {
            _usersService = usersService;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public ApiRespose Login(Users user)
        {
            var Username = user.username!;
            var Password = user.password!;
            bool isAuthenticated = _usersService.AuthenticateUser(Username, Password);
            if (isAuthenticated != true)
            {
                return new ApiRespose
                {
                    Success = false,
                    Message = "Authentication failed",
                    Data = null
                };

            }
            return new ApiRespose
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            };
        }
        private string GenerateToken(Users Account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey!);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, Account.username!),

                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                    (secretKeyBytes), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }

        [HttpPost("Signup")]
        public Users PostAccount(Users account)
        {
            return _usersService.CreatAccount(account);
        }

        [HttpPut("ChangePass")]
        public Users PutPassAccount(Users account)
        {
            return _usersService.UpdatePassAcc(account);
        }

        [HttpDelete("DeleteUser")]
        public string DeleteAccount(int id)
        {
            return _usersService.RemoveAcc(id);
        }
    }
}
