using System;
using System.Collections.Generic;

namespace ApiRest_Ferralla.Models
{
    public partial class ImagenArticulo
    {
        public int Id { get; set; }
        public string Ruta { get; set; }
        public bool Activo { get; set; }
        public int ArticuloId { get; set; }
        public bool Principal { get; set; }

        //public Articulo Articulo { get; set; }
    }
}
