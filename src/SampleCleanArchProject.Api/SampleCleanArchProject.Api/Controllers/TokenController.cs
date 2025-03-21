using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleCleanArchProject.Api.Models;
using SampleCleanArchProject.Domain.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleCleanArchProject.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _autentication;
        private readonly IConfiguration _configuration;
        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            this._autentication = authenticate;
            _configuration = configuration;
        }

        [HttpPost("login-user")]
        public async Task<ActionResult<UserToken>> Login([FromBody]LoginModel user)
        {
            var result = await _autentication.Authenticate(user.Email, user.Password);

            if (result)
                return GenerateToken(user);
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _autentication.Register(request.Email, request.Password);

            if (result)
                return Ok(new { message = "Registrado com sucesso" });

            return BadRequest();
        }

        private UserToken GenerateToken(LoginModel user)
        {
            var claims = new[]
            {
                new Claim("email", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));


            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(20);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };         
        }
    }
}