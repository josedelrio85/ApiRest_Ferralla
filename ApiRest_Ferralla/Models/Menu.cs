
namespace ApiRest_Ferralla.Models
{
    public class Menu
    {
        public string controlador { get; set; }
        public string accion { get; set; }
        public string nombre { get; set; }
        public int orden { get; set; }

        public Menu(string nom, string acc, string contr, int orden)
        {
            this.controlador = contr;
            this.accion = acc;
            this.nombre = nom;
            this.orden = orden;
        }
    }
}
