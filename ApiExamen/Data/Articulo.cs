using System;
using System.Collections.Generic;

#nullable disable

namespace ApiExamen.Data
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string CodigoCn { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public string Imagen { get; set; }
        public int? Stock { get; set; }
    }
}
