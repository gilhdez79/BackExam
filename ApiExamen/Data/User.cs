using System;
using System.Collections.Generic;

#nullable disable

namespace ApiExamen.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public string Rol { get; set; }
    }
}
