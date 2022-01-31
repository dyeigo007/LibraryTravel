using BrowserTravel.LibraryTravel.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrowserTravel.LibraryTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(UserLogin user)
        {
            if (IsValidateUser(user))
            {
                var token = GenerateToken();
                return Ok(new { token });
            }
            return NotFound();
        }

        private bool IsValidateUser(UserLogin user) {
            return true;
        }

        private string GenerateToken()
        {

            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Autentication:SecretKey"]));
            var signingCrededntials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCrededntials);

            //claim
            var claim = new[]
            {
                new Claim(ClaimTypes.Name,"Diego"),
                new Claim(ClaimTypes.Email,"dyeigo007@gmail.com")
            };

            //payload
            var payload = new JwtPayload
            (
                _configuration["Autentication:Emisor"],
                _configuration["Autentication:Audience"],
                claim,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(100)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
