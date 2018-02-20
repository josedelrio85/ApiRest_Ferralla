using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiRest_Ferralla.Models;
using Microsoft.AspNetCore.Routing;

namespace ApiRest_Ferralla.Controllers
{
    [Route("api/menu")]
    public class MenuController : Controller
    {
        [HttpGet]
        public List<Menu> GetAll()
        {
            List<Menu> lista = new List<Menu>()
            {
                new Menu("Empresa", "Empresa", "empresa", 1),
                new Menu("Productos", "Productos", "productos", 2),
                new Menu("Obras Ejecutadas", "Index", "obras", 3),
                new Menu("Contacto", "Contact", "contacto", 4),
                new Menu("Ayudas", "Ayudas", "ayudas", 5),
                new Menu("Salir", "Logout", "logout", 6),
                new Menu("Acceder", "Login", "login", 7)
            };
            return lista.OrderBy(t => t.orden).ToList();
        }
    }
}