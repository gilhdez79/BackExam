using ApiExamen.BsLayer;
using ApiExamen.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ApiExamen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;

namespace ApiExamen.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private BsLogin bsLogin;
        private Data.ExamendbContext _db;
        private IConfiguration _config;



        public UserController(Data.ExamendbContext db, IConfiguration config)
        {
            _db = db;

            bsLogin = new BsLogin(_db);

            _config = config;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
      
        public IActionResult Login([FromBody] UserLogin user)
        {
            try
            {
                var userAth = Authenticate(user);
                var result = bsLogin.GetCUser(user);

                if (userAth != null)
                {
                    var token = Generate(userAth);

                    return Ok(token);

                }



                return NotFound("Usuario no Registrado");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("Admins")]
      
        public IActionResult AdmindEndPint()
        {
            var currenUser = GetCurrentUser();

            return Ok($"Hi {currenUser.UserName}");
        }

        public UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,



                };
            }
            return null;
 
        }

        private UserModel Authenticate([FromBody] UserLogin user)
        {
            var currentUser = bsLogin.GetCUser(user);

            if (currentUser !=null)
            {
                UserModel usr = new UserModel() {
                    UserName = currentUser.ObjReturn.UserName,
                    Password = currentUser.ObjReturn.Password,
                    EmailAddress = currentUser.ObjReturn.EmailAddress,
                    GivenName = currentUser.ObjReturn.GivenName,
                    Role = currentUser.ObjReturn.Rol,
                    Surname = currentUser.ObjReturn.Surname

                };
                return usr;
            }

            return null;
        }

        private string Generate(UserModel user)
        {
            var securutyKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Role, user.Role)

            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audence"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials:credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
