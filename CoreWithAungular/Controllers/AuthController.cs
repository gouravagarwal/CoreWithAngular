using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreWithAungular.Models;
using CoreWithAungular.Models.ApplicationClass;
using CoreWithAungular.Repository.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoreWithAungular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        #region Private variables and Constructor
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        #endregion

        #region Public Methods

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModelAC userAC)
        {
            if (userAC == null)
                return BadRequest("Invalid Client Request");

            UserDetails user = _userRepository.GetUserByUserName(userAC.UserName);
            if (user != null && userAC.Password == user.UserPassword)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
                var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.FullName));
                claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
                claims.Add(new Claim(ClaimTypes.Email, user.EmailId));
                claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));

                if (user.UserType == "SA" || user.UserType == "A")
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                else
                    claims.Add(new Claim(ClaimTypes.Role, "User"));

                var tokenOptions = new JwtSecurityToken(
                    issuer: _config["Token:Issuer"],
                    audience: _config["Token:Issuer"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signInCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new { Token = tokenString });
            }
            else
                return Unauthorized();

        }

        #endregion

    }
}