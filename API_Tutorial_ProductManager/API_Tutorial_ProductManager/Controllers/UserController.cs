using API_Tutorial_ProductManager.Data;
using API_Tutorial_ProductManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Tutorial_ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DContext _context;
        private readonly AppSettings _appSettings;

        public UserController(DContext context, IOptionsMonitor<AppSettings> optionsMonitor) 
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.users.SingleOrDefault(p => p.UserName == model.UserName && model.Password == p.Password);
            if (user == null) //Sai thông tin người dùng
            {
                return Ok(new ApiResponse
                {
                    Success = false, 
                    Message = "Invalid username/password"
                });
            }

            //cấp token
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate Success",
                Data = GenerateToken(user)
            });
        } 

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("UserName",user.UserName),
                    new Claim("Id",user.Id.ToString()),



                    new Claim("TokenId",Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
                
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
