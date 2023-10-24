using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnDojo.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, string> datosNinja = new Dictionary<string, string>();

        public List<string> ubicacion = new List<string>()
            {
                "Valparaíso",
                "Viña del Mar",
                "Santiago"
            };

        public List<string> languages = new List<string>()
            {
                "CSharp",
                "Java",
                "SQL"
            };

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Localizacion = ubicacion;
            ViewBag.Lenguajes = languages;

            if (datosNinja.Count > 0)
            {
                datosNinja.Clear();
            }

            return View();
        }

        [HttpPost("result")]
        public IActionResult Index(string Nombre, string Ubicacion, string Lenguaje, string? Comentario)
        {
            if (datosNinja.Count == 0)
            {
                datosNinja.Add("Nombre", Nombre);
                datosNinja.Add("Ubicacion", Ubicacion);
                datosNinja.Add("Lenguaje", Lenguaje);
                datosNinja.Add("Comentario", Comentario);

                ViewBag.Datos = datosNinja;

                return View("result", datosNinja);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("result")]
        public IActionResult Resultado()
        {
            ViewBag.Datos = datosNinja;
            return View("result", datosNinja);
        }
    }
}