using CRUDPractica.Datos;
using CRUDPractica.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDPractica.Controllers
{
    public class PersonaController : Controller
    {
        PersonDatos person = new PersonDatos();
        public IActionResult Listar()
        {
            //Vista que mostrara a las personas
            var oLista = person.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Vista para guardar una persona
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PersonModel oPersona)
        {
            //Vista para guardar una persona en BD
            var respuesta = person.Guardar(oPersona);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();

        }

        public IActionResult Editar(int id)
        {
            var person2 = person.Obtener(id);
            //Vista para guardar una persona
            return View(person2);
        }

        [HttpPost]
        public IActionResult Editar(PersonModel oPersona)
        {
            //Vista para guardar una persona en BD
            var respuesta = person.Editar(oPersona);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();

        }
    }
}
