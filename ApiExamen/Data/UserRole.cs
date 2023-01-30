using System;
using System.Collections.Generic;

#nullable disable

namespace ApiExamen.Data
{
    public partial class UserRole
    {
        public int? IdRol { get; set; }
        public int? IdUser { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
