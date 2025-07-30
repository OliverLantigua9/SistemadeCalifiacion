using ClasificacionesDeEstudiantes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClasificacionesDeEstudiantes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private static List<Materia> materias = new();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult Get() => Ok(materias);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var materia = materias.FirstOrDefault(m => m.Id == id);
            if (materia == null) return NotFound();
            return Ok(materia);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            materia.Id = nextId++;
            materias.Add(materia);
            return CreatedAtAction(nameof(Get), new { id = materia.Id }, materia);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Materia materia)
        {
            var existing = materias.FirstOrDefault(m => m.Id == id);
            if (existing == null) return NotFound();
            existing.NombreMateria = materia.NombreMateria;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var materia = materias.FirstOrDefault(m => m.Id == id);
            if (materia == null) return NotFound();
            materias.Remove(materia);
            return NoContent();
        }
    }
}