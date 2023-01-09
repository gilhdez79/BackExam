using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExamen.BsLayer;

namespace ApiExamen.Controllers
{
    [ApiController]
    [Route("api/articulo")]
    public class ArticuloController : ControllerBase
    {
        private BsArticulo bsArticulo;
        private Data.ExamendbContext _db;
        public ArticuloController(Data.ExamendbContext db)
        {
            _db = db;

            bsArticulo = new BsArticulo(_db);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var datos = _db.Articulos.ToList();
            return Ok(datos);
        }
        [HttpPost]
        public IActionResult InsertaArticulo([FromBody] Data.Articulo articulo)
        {
            var result = bsArticulo.InsetArticulo(articulo);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateArticulo([FromBody] Data.Articulo articulo)
        {
            var result = bsArticulo.UpdateArticulo(articulo);

            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteArticulo([FromBody] Data.Articulo articulo)
        {
            var result = bsArticulo.UpdateArticulo(articulo);

            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArticulo(int id)
        {
            var result = bsArticulo.GetArticulo(id);

            return Ok(result);
        }
        [HttpGet]
        [Route("/")]
        public IActionResult GetAllArticulo()
        {
            var result = bsArticulo.GetAllArticulo();

            return Ok(result);
        }
    }
}
