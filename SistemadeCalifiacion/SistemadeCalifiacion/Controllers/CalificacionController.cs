using ClasificacionesDeEstudiantes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClasificacionesDeEstudiantes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificacionController : ControllerBase
    {
        private static List<Calificacion> calificaciones = new();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult Get() => Ok(calificaciones);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var calificacion = calificaciones.FirstOrDefault(c => c.Id == id);
            if (calificacion == null) return NotFound();
            return Ok(calificacion);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Calificacion calificacion)
        {
            if (!ValidarRangos(calificacion))
                return BadRequest("Las calificaciones deben estar entre 0 y 100.");

            calificacion.Id = nextId++;
            CalcularResultados(calificacion);
            calificaciones.Add(calificacion);
            return CreatedAtAction(nameof(Get), new { id = calificacion.Id }, calificacion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Calificacion calificacion)
        {
            var existing = calificaciones.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();

            if (!ValidarRangos(calificacion))
                return BadRequest("Las calificaciones deben estar entre 0 y 100.");

            existing.EstudianteId = calificacion.EstudianteId;
            existing.MateriaId = calificacion.MateriaId;
            existing.Calificacion1 = calificacion.Calificacion1;
            existing.Calificacion2 = calificacion.Calificacion2;
            existing.Calificacion3 = calificacion.Calificacion3;
            existing.Calificacion4 = calificacion.Calificacion4;
            existing.Examen = calificacion.Examen;
            CalcularResultados(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var calificacion = calificaciones.FirstOrDefault(c => c.Id == id);
            if (calificacion == null) return NotFound();
            calificaciones.Remove(calificacion);
            return NoContent();
        }

        private static void CalcularResultados(Calificacion c)
        {
            var promedio = (c.Calificacion1 + c.Calificacion2 + c.Calificacion3 + c.Calificacion4) / 4;
            c.Total = (promedio * 0.7m) + (c.Examen * 0.3m);

            if (c.Total >= 90)
                c.Clasificacion = "A";
            else if (c.Total >= 80)
                c.Clasificacion = "B";
            else if (c.Total >= 70)
                c.Clasificacion = "C";
            else
                c.Clasificacion = "F";

            c.Estado = c.Total >= 70 ? "Aprobado" : "Reprobado";
        }

        private static bool ValidarRangos(Calificacion c)
        {
            return c.Calificacion1 >= 0 && c.Calificacion1 <= 100 &&
                   c.Calificacion2 >= 0 && c.Calificacion2 <= 100 &&
                   c.Calificacion3 >= 0 && c.Calificacion3 <= 100 &&
                   c.Calificacion4 >= 0 && c.Calificacion4 <= 100 &&
                   c.Examen >= 0 && c.Examen <= 100;
        }
    }
}