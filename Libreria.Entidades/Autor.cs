using System.ComponentModel;

namespace Libreria.Entidades
{
    public class Autor
    {
        // Información de Autor
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set;}
        public string Nacionalidad { get; set; }

        //Relaciones con otras entidades
        public List<Libro>? Libros { get;}
    }
}