using Microsoft.AspNetCore.Mvc;
using CRUDPractica.Datos;
using CRUDPractica.Models;

namespace CRUDPractica.Controllers
{
    public class PersonaController1 : Controller
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
    }
}
