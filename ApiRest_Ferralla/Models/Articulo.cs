using System;
using System.Collections.Generic;

namespace ApiRest_Ferralla.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            ImagenArticulo = new HashSet<ImagenArticulo>();
        }

        public int Id { get; set; }
        public string Anho { get; set; }
        public string Lugar { get; set; }
        public string Contratista { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
        public bool Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TipoArticuloId { get; set; }

        public ICollection<ImagenArticulo> ImagenArticulo { get; set; }
    }
}
