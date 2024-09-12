namespace libreria_frontend.Models
{
    public class Autor
    {
        public long Autor_id { get; set; }
        public string Rut { get; set; }
        public string Nombre_completo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
