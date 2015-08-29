using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DirectorioPersonas.Models;
using DirectorioPersonas.ViewModels;

namespace DirectorioPersonas.Controllers
{
    public class PersonaController : Controller
    {
        public ActionResult Index()
        {
            return View(DataProvider.ObtenerPersonas());
        }

        public ActionResult VistaParcial()
        {
            return PartialView("GridViewPersona", DataProvider.ObtenerPersonas());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Adicionar(PersonaVM persona)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.AdicionarPersona(persona);
                }
                catch (Exception e)
                {
                    ViewData["ErroresEdicion"] = e.Message;
                }
            }
            else
            {
                ViewData["ErroresEdicion"] = "El formulario contiene errores de validación.";
            }

            return PartialView("GridViewPersona", DataProvider.ObtenerPersonas());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Modificar(PersonaVM persona)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.ModificarPersona(persona);
                }
                catch (Exception e)
                {
                    ViewData["ErroresEdicion"] = e.Message;
                }
            }
            else
            {
                ViewData["ErroresEdicion"] = "El formulario contiene errores de validación.";
            }

            return PartialView("GridViewPersona", DataProvider.ObtenerPersonas());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Eliminar(int personaID)
        {
            try
            {
                DataProvider.EliminarPersona(personaID);
            }
            catch (Exception e)
            {
                ViewData["ErroresEdicion"] = e.Message;
            }

            return PartialView("GridViewPersona", DataProvider.ObtenerPersonas());
        }

        public ActionResult ActualizarImagen()
        {
            return BinaryImageEditExtension.GetCallbackResult();
        }
    }
}