﻿using Event.DOM;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManagmentMVCCore.Controllers
{   
    [EnableCors("AllowMyOrigin")]
    public class SeurityController : Controller
    {
        public IConfiguration _config = null;

        public SeurityController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        // Step 1 :- Generate 
        public string GenerateJSONWebToken()
        {
            // when he is validated AD

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "shiv"),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IActionResult Login([FromBody] Registration user)
        {
            if (user.Username == "QP")
            {
                string str = GenerateJSONWebToken();

                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Security issues");
            }
        }
    }
}
