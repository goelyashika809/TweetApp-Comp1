using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TweetApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthenticationController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        [Route("GenerateJwtToken")]
        public string GenerateJwtToken(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Role, userName),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(this.config["JwtExpireHours"]));
            
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                this.config["JwtIssuer"],
                this.config["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials));
        }
    }
}
