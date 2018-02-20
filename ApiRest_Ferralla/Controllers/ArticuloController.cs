using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiRest_Ferralla.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_Ferralla.Controllers
{
    [Route("api/articulo")]
    public class ArticuloController : Controller
    {
        private readonly FerrallaContext _context;

        public ArticuloController(FerrallaContext context)
        {
            _context = context;

            if (_context.Articulo.Count() == 0)
            {
                _context.Articulo.Add(new Articulo {
                    Activo = true,
                    Anho = System.DateTime.Now.Year.ToString(),
                    Contratista = "Prueba",
                    Descripcion = "Probando",
                    FechaCreacion = System.DateTime.Now,
                    Lugar = "Lugar de prueba",
                    Foto = false,
                    TipoArticuloId = 1
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Articulo> GetAll()
        {         
            IEnumerable<Articulo> l = _context.Articulo
                .Where(x => x.Activo == true)
                .Where(x => x.TipoArticuloId == 1)
                .Include(ia => ia.ImagenArticulo)
                .ToList();
            return l;
        }


        [HttpGet("{id}", Name ="GetArticulo")]
        public IActionResult GetById(int id)
        {
            var item = _context.Articulo
                .Include(ia => ia.ImagenArticulo)
                .FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Articulo articulo)
        {
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulo.Add(articulo);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = articulo.Id }, articulo);
        }

        /*
         * The response is 204 (No Content). According to the HTTP spec, 
         * a PUT request requires the client to send the entire updated entity, not just the deltas. 
         * To support partial updates, use HTTP PATCH.
         */
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Articulo item)
        {
            if (id != item.Id || item == null)
            {
                return BadRequest();
            }

            var element = _context.Articulo.FirstOrDefault(t => t.Id == item.Id);
            if (element == null)
            {
                return NotFound();
            }

            element.Activo = item.Activo;
            element.Anho = item.Anho;
            element.Contratista = item.Contratista;
            element.Descripcion = item.Descripcion;
            element.FechaCreacion = item.FechaCreacion;
            element.Foto = item.Foto;
            element.ImagenArticulo = item.ImagenArticulo;
            element.Lugar = item.Lugar;
            element.TipoArticuloId = item.TipoArticuloId;

            _context.Articulo.Update(element);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var element = _context.Articulo.FirstOrDefault(t => t.Id == id);
            if (element == null)
            {
                return NotFound();
            }

            _context.Articulo.Remove(element);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}