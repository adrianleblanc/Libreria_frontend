namespace libreria_frontend.Models
{
    public class Libro
    {
        public long Libro_id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public int Cantidad_paginas { get; set; }
        public long Autor_id { get; set; }
        public string AutorRut { get; set; }
    }
}