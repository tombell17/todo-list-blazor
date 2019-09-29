using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public LoginController(IConfiguration configuration,
                               SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginRequest login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new LoginResult
                {
                    Successful = false,
                    Errors = new List<string> { "invalid username or password" }
                });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Email)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"])),
                signingCredentials: credentials
            );

            return Ok(new LoginResult
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }
    }
}
