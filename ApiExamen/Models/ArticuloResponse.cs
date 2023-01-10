using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.Models
{
  
    public class ArticuloResponse
    { 
        public string CodigoCn { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public string Imagen { get; set; }
        public int? Stock { get; set; }
    }
}
