using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamen.Models
{
    public class Tienda
    {
        [Key]
        public int id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
    }
}
