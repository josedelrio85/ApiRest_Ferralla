using System;
using System.Collections.Generic;

namespace ApiRest_Ferralla.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public short Permisos { get; set; }
    }
}
