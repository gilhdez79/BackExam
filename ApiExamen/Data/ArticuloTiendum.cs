using System;
using System.Collections.Generic;

#nullable disable

namespace ApiExamen.Data
{
    public partial class ArticuloTiendum
    {
        public int? IdArticulo { get; set; }
        public int? IdTienda { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Tienda2 IdTiendaNavigation { get; set; }
    }
}
