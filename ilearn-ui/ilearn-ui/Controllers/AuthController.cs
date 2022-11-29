using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ilearn_ui.domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ilearn_ui.Controllers
{
    [Route("v1/auth")]
    public class AuthController : Controller
    {
        private readonly JWTSettings _jwtsettings;

        public AuthController(IOptions<JWTSettings> jwtSettings)
        {
            _jwtsettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Authenticate([FromBody] User model)
        {
            var user = new User
            {
                Id = "1",
                Name = "Haline Silva",
                Email = "halineferreira@gmail.com",
                Address = new Address(),
                Phone = "11",
                Password = "123"

            };

            if (user == null)
            {
                return NotFound(new { message = "Email ou senha inválidos" });
            }

            var token = GenerateAccessToken(user);
            return new UserToken
            {
                User = user,
                Token = token

            };
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        

        }
    }
}
