using ClasificacionesDeEstudiantes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClasificacionesDeEstudiantes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private static List<Estudiante> estudiantes = new();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult Get() => Ok(estudiantes);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estudiante estudiante)
        {
            estudiante.Id = nextId++;
            estudiantes.Add(estudiante);
            return CreatedAtAction(nameof(Get), new { id = estudiante.Id }, estudiante);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            var existing = estudiantes.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = estudiante.Nombre;
            existing.Matricula = estudiante.Matricula;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null) return NotFound();
            estudiantes.Remove(estudiante);
            return NoContent();
        }
    }
}