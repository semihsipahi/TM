using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TM.Core.Entity;
using TM.Imp.Concrete;
using TM.Imp.DTO;

namespace TM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new(new Core.Data.TodoContext());

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {
            var exist = unitOfWork.UserRepository.GetUser(user.Email, user.Password);

            if (exist == null)
            {
                return Unauthorized();
            }

            var token = CreateAndGetToken(exist);

            return Ok(new
            {
                Token = token,
                User = user,
            });
        }

        static string CreateAndGetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("m6D4n9Y3r7bX0P2ZfL1uJ8QwJ5kV7yA3zR6X0Z2B9M8F4A5G7J1W3L0R9N8P2S");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.PKUserId.ToString()),
                    new(ClaimTypes.Email, user.EMail)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}