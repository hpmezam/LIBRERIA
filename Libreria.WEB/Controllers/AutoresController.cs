using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria.APIConsumer;
using Libreria.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.WEB.Controllers
{
    public class AutoresController : Controller
    {
        private readonly string urlBase;
        public AutoresController(IConfiguration configuration)
        {
            urlBase = configuration["UrlBase"].ToString() + "Autores/";
        }

        // Construimos una lista de Nacionalidades
        private List<SelectListItem> listaNacionalidades()
        {
            var nacionalidades = new List<SelectListItem>();                    
            nacionalidades.Add(new SelectListItem { Text = "ALEMANIA", Value = "ALEMANIA" });
            nacionalidades.Add(new SelectListItem { Text = "AUSTRALIA", Value = "AUSTRALIA" });
            nacionalidades.Add(new SelectListItem { Text = "CANADÁ", Value = "CANADÁ" });
            nacionalidades.Add(new SelectListItem { Text = "CHINA", Value = "CHINA" });
            nacionalidades.Add(new SelectListItem { Text = "ECUADOR", Value = "ECUADOR" });
            nacionalidades.Add(new SelectListItem { Text = "ESPAÑA", Value = "ESPAÑA" });
            nacionalidades.Add(new SelectListItem { Text = "ESTADOS UNIDOS", Value = "ESTADOS UNIDOS" });
            nacionalidades.Add(new SelectListItem { Text = "FRANCIA", Value = "FRANCIA" });
            nacionalidades.Add(new SelectListItem { Text = "ITALIA", Value = "ITALIA" });
            nacionalidades.Add(new SelectListItem { Text = "MÉXICO", Value = "MÉXICO" });
            nacionalidades.Add(new SelectListItem { Text = "PERÚ", Value = "PERÚ" });
            nacionalidades.Add(new SelectListItem { Text = "REINO UNIDO", Value = "REINO UNIDO" });
            nacionalidades.Add(new SelectListItem { Text = "VENEZUELA", Value = "VENEZUELA" });
            return nacionalidades;
        }

        // GET: AutoresController
        public ActionResult Index()
        {
            var datos = Crud<Autor>.Select(urlBase);
            return View(datos);
        }

        // GET: AutoresController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud<Autor>.Select_One(urlBase + id.ToString());
            return View(datos);
        }

        // GET: AutoresController/Create
        public ActionResult Create()
        {
            var datos=Crud<Autor>.Select(urlBase);
            ViewBag.ListaNacionalidad = listaNacionalidades();
            return View();
        }

        // POST: AutoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor datos)
        {
            try
            {
                Crud<Autor>.Insert(urlBase, datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: AutoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud<Autor>.Select_One(urlBase + id.ToString());
            ViewBag.ListaNacionalidad = listaNacionalidades();
            return View(datos);
        }

        // POST: AutoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor datos)
        {
            try
            {
                Crud<Autor>.Update(urlBase + id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(datos);
            }
        }

        // GET: AutoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud<Autor>.Select_One(urlBase + id.ToString());
            return View(datos);
        }

        // POST: AutoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Autor datos)
        {
            try
            {
                Crud<Autor>.Delete(urlBase + id.ToString());
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
