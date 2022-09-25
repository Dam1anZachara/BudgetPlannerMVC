using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

namespace BudgetPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IUserRoleService _userRoleService;
        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config, IUserRoleService userRoleService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRoleService = userRoleService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel loginModel)
        {
            IActionResult response = Unauthorized();
            var success = AuthenticateUser(loginModel);

            if (success)
            {
                var tokenString = GenerateJsonWebToken(loginModel);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJsonWebToken(UserModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var user = _userManager.Users.FirstOrDefault(u => u.Email == loginModel.Email);

            var userRole = _userRoleService.GetUserRoleIdByUserId(user.Id);
            var userClaims = new List<Claim>();
            var claim = new Claim(ClaimTypes.Role, userRole);
            userClaims.Add(claim);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims: userClaims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(UserModel loginModel)
        {
            var result = _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, lockoutOnFailure: false).Result;
            return result.Succeeded;
        }

    }
}
