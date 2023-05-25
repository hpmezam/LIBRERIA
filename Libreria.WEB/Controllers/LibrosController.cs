using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria.APIConsumer;
using Libreria.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.WEB.Controllers
{
    public class LibrosController : Controller
    {
        private readonly string urlBase;
        public LibrosController(IConfiguration configuration)
        {
            urlBase = configuration["UrlBase"].ToString() + "Libros/";
        }

        // Construimos una lista de Géneros de libros
        private List<SelectListItem> listaGenerosLibro()
        {
            var generos = new List<SelectListItem>();            
            generos.Add(new SelectListItem { Text = "NO FICCIÓN", Value = "NO FICCIÓN" });
            generos.Add(new SelectListItem { Text = "AUTOAYUDA", Value = "AUTOAYUDA" });
            generos.Add(new SelectListItem { Text = "AVENTURA", Value = "AVENTURA" });
            generos.Add(new SelectListItem { Text = "BIOGRAFÍA", Value = "BIOGRAFÍA" });
            generos.Add(new SelectListItem { Text = "CIENCIA FICCIÓN", Value = "CIENCIA FICCIÓN" });
            generos.Add(new SelectListItem { Text = "DRAMA", Value = "DRAMA" });
            generos.Add(new SelectListItem { Text = "ECONOMÍA", Value = "ECONOMÍA" });
            generos.Add(new SelectListItem { Text = "ENSAYO", Value = "ENSAYO" });
            generos.Add(new SelectListItem { Text = "FANTASÍA", Value = "FANTASÍA" });
            generos.Add(new SelectListItem { Text = "FICCIÓN", Value = "FICCIÓN" });
            generos.Add(new SelectListItem { Text = "FILOSOFÍA", Value = "FILOSOFÍA" });
            generos.Add(new SelectListItem { Text = "HISTÓRICO", Value = "HISTÓRICO" });
            generos.Add(new SelectListItem { Text = "MISTERIO", Value = "MISTERIO" });           
            generos.Add(new SelectListItem { Text = "POESÍA", Value = "POESÍA" });
            generos.Add(new SelectListItem { Text = "POLICIAL", Value = "POLICIAL" });
            generos.Add(new SelectListItem { Text = "PSICOLOGÍA", Value = "PSICOLOGÍA" });
            generos.Add(new SelectListItem { Text = "ROMANCE", Value = "ROMANCE" });
            generos.Add(new SelectListItem { Text = "SUSPENSO", Value = "SUSPENSO" });
            generos.Add(new SelectListItem { Text = "TERROR", Value = "TERROR" });
            generos.Add(new SelectListItem { Text = "THRILLER", Value = "THRILLER" });                                   
            return generos;
        }

        // Construimos una lista de Editoriales de libros
        private List<SelectListItem> listaEditorialesLibro()
        {
            var editoriales = new List<SelectListItem>();
            editoriales.Add(new SelectListItem { Text = "Penguin Random House", Value = "Penguin Random House" });
            editoriales.Add(new SelectListItem { Text = "HarperCollins", Value = "HarperCollins" });
            editoriales.Add(new SelectListItem { Text = "Hachette Livre", Value = "Hachette Livre" });
            editoriales.Add(new SelectListItem { Text = "Simon & Schuster", Value = "Simon & Schuster" });
            editoriales.Add(new SelectListItem { Text = "Macmillan Publishers", Value = "Macmillan Publishers" });
            editoriales.Add(new SelectListItem { Text = "Scholastic Corporation", Value = "Scholastic Corporation" });
            editoriales.Add(new SelectListItem { Text = "Wiley", Value = "Wiley" });
            editoriales.Add(new SelectListItem { Text = "Pearson Education", Value = "Pearson Education" });
            editoriales.Add(new SelectListItem { Text = "Bloomsbury Publishing", Value = "Bloomsbury Publishing" });
            editoriales.Add(new SelectListItem { Text = "Oxford University Press", Value = "Oxford University Press" });
            editoriales.Add(new SelectListItem { Text = "Cambridge University Press", Value = "Cambridge University Press" });
            editoriales.Add(new SelectListItem { Text = "Springer", Value = "Springer" });
            editoriales.Add(new SelectListItem { Text = "Elsevier", Value = "Elsevier" });
            editoriales.Add(new SelectListItem { Text = "Penguin Books", Value = "Penguin Books" });
            editoriales.Add(new SelectListItem { Text = "Vintage Books", Value = "Vintage Books" });
            editoriales.Add(new SelectListItem { Text = "Little, Brown and Company", Value = "Little, Brown and Company" });
            editoriales.Add(new SelectListItem { Text = "Farrar, Straus and Giroux", Value = "Farrar, Straus and Giroux" });
            editoriales.Add(new SelectListItem { Text = "Knopf Doubleday Publishing Group", Value = "Knopf Doubleday Publishing Group" });
            editoriales.Add(new SelectListItem { Text = "Random House", Value = "Random House" });
            editoriales.Add(new SelectListItem { Text = "MIT Press", Value = "MIT Press" });
            return editoriales;
        }

        // Construimos una lista de Autores de libros
        private List<SelectListItem> listaAutores()
        {
            var vuelos = Crud<Autor>.Select(urlBase.Replace("Libros", "Autores"));
            var lista = vuelos.Select(autor => new SelectListItem
            {
                Value = autor.Id.ToString(),
                Text = autor.Nombre + " " + autor.Apellido
            }).ToList();
            return lista;
        }





        // GET: LibrosController
        public ActionResult Index()
        {
            var datos = Crud<Libro>.Select(urlBase);
            return View(datos);
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud<Libro>.Select_One(urlBase + id.ToString());
            return View(datos);
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {

            ViewBag.ListaAutor = listaAutores();
            ViewBag.ListaEditorial = listaEditorialesLibro();
            ViewBag.ListaGenero = listaGenerosLibro();

            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro datos)
        {
            try
            {
                Crud<Libro>.Insert(urlBase, datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: LibrosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud<Libro>.Select_One(urlBase + id.ToString());
            ViewBag.ListaAutor = listaAutores();
            ViewBag.ListaEditorial = listaEditorialesLibro();
            ViewBag.ListaGenero = listaGenerosLibro();
            return View(datos);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro datos)
        {
            try
            {
                Crud<Libro>.Update(urlBase + id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(datos);
            }
        }

        // GET: LibrosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud<Libro>.Select_One(urlBase + id.ToString());
            return View(datos);
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Libro datos)
        {
            try
            {
                Crud<Libro>.Delete(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(datos);
            }
        }
    }
}
