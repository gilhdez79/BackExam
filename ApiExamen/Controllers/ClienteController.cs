using ApiExamen.BsLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private BsCliente bsCliente;
        private Data.ExamendbContext _db;

        public ClienteController(Data.ExamendbContext db)
        {
            _db = db;

            bsCliente = new BsCliente(_db);
        }
        public IActionResult Index()
        {
            var datos = _db.Clientes.ToList();
            return Ok(datos);
        }

        [HttpPost]
        public IActionResult InsertaCliente([FromBody] Data.Cliente cliente)
        {
            var result = bsCliente.InsetCliente(cliente);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateCliente([FromBody] Data.Cliente cliente)
        {
            var result = bsCliente.UpdateCliente(cliente);

            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteCliente([FromBody] Data.Cliente cliente)
        {
            var result = bsCliente.UpdateCliente(cliente);

            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCliente(int id)
        {
            var result = bsCliente.GetCliente(id);

            return Ok(result);
        }
        [HttpGet]
        [Route("/")]
        public IActionResult GetAllCliente()
        {
            var result = bsCliente.GetAllCliente();

            return Ok(result);
        }
    }
}
