using System;
using System.Collections.Generic;

namespace ApiRest_Ferralla.Models
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Texto { get; set; }
    }
}
