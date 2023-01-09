using System;
using System.Collections.Generic;

#nullable disable

namespace ApiExamen.Data
{
    public partial class ClienteArticulo
    {
        public int? IdCliente { get; set; }
        public int? IdArticulo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
