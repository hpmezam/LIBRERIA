// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var autores = Libreria.APIConsumer.Crud<Libreria.Entidades.Autor>.Select("http://localhost:7042/api/Autores");
//var libros = Libreria.APIConsumer.Crud<Libreria.Entidades.Libro>.Select("http://localhost:7042/api/Libros");
Console.ReadKey();