using ClasificacionesDeEstudiantes.Models;
using Microsoft.EntityFrameworkCore;
using SistemadeCalifiacion.Models;

namespace SistemadeCalifiacion.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
}