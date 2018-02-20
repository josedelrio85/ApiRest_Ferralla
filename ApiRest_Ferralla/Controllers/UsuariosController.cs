using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiRest_Ferralla.Models;

namespace ApiRest_Ferralla.Controllers
{
    [Route("api/usuario")]
    public class UsuariosController : Controller
    {
        private readonly FerrallaContext _context;

        public UsuariosController(FerrallaContext context)
        {
            _context = context;

            if (_context.Usuario.Count() == 0)
            {
                _context.Usuario.Add(new Usuario { Nombre = "Prueba", Login = "Prueba", Activo = true, Permisos = 1 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        [HttpGet("{id}", Name= "GetUsuarios")]
        public IActionResult GetById(int id)
        {
            var item = _context.Usuario.FirstOrDefault(t => t.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /*
         * The [FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
         */
        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if(usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsuarios", new { id = usuario.Id }, usuario);            
        }

        /*
         * The response is 204 (No Content). According to the HTTP spec, 
         * a PUT request requires the client to send the entire updated entity, not just the deltas. 
         * To support partial updates, use HTTP PATCH.
         */
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id || usuario == null)
            {
                return BadRequest();
            }

            var user = _context.Usuario.FirstOrDefault(t => t.Id == usuario.Id);
            if(user == null)
            {
                return NotFound();
            }

            user.Nombre = usuario.Nombre;
            user.Login = usuario.Login;
            user.Password = usuario.Password;
            user.Permisos = usuario.Permisos;
            user.Activo = usuario.Activo;

            _context.Usuario.Update(user);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Usuario.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(user);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
