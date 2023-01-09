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

    public class TiendaController : ControllerBase
    {
        private BsTienda bsTienda;
        private Data.ExamendbContext _db;
        public TiendaController(Data.ExamendbContext db)
        {
            _db = db;

            bsTienda = new BsTienda(_db);
        }
        public IActionResult Index()
        {
            var datos = _db.Tienda.ToList();
            return Ok(datos);
        }
        [HttpPost]
        public IActionResult InsertaTienda([FromBody] Data.Tienda tienda)
        {
            var result = bsTienda.InsetTienda(tienda);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateTienda([FromBody] Data.Tienda tienda)
        {
            var result = bsTienda.UpdateTienda(tienda);

            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteTienda([FromBody] Data.Tienda tienda)
        {
            var result = bsTienda.UpdateTienda(tienda);

            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTienda(int id)
        {
            var result = bsTienda.GetTienda(id);

            return Ok(result);
        }
        [HttpGet]
        [Route("/")]
        public IActionResult GetAllTienda()
        {
            var result = bsTienda.GetAllTienda();

            return Ok(result);
        }
    }
}
