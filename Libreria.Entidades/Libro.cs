using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class Libro
    {
        // Información de Libro
        public int Id { get; set; }
        public string Titulo { get; set; }
        [DisplayName("Género")]
        public string Genero { get; set; }
        [DisplayName("Año de Publicación")]
        public int AñoPublicacion { get; set; }
        public string Editorial { get; set; }

        // Clave FK
        [DisplayName("Autor")]
        public int AutorId { get; set; }

        //Relaciones con otras entidades
        public Autor? Autor { get; set; }
    }
}
