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


namespace ApiExamen.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private BsLogin bsLogin;
        private Data.ExamendbContext _db;

        public UserController(Data.ExamendbContext db)
        {
            _db = db;

            bsLogin = new BsLogin(_db);
        }
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]      
        [Route("login")]   
        public IActionResult Login([FromBody] User user)
        {
            var result = bsLogin.GetCUser(user);

            return Ok(result);
        }

    }
}
