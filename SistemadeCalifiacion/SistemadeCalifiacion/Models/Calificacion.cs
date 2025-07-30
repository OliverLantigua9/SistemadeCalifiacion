namespace ClasificacionesDeEstudiantes.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public decimal Calificacion1 { get; set; }
        public decimal Calificacion2 { get; set; }
        public decimal Calificacion3 { get; set; }
        public decimal Calificacion4 { get; set; }
        public decimal Examen { get; set; }
        public decimal Total { get; set; }
        public string Clasificacion { get; set; }
        public string Estado { get; set; }
    }
}