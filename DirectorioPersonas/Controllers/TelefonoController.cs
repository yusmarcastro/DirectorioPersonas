using System;
using System.Web.Mvc;
using DirectorioPersonas.Models;
using DirectorioPersonas.ViewModels;

namespace DirectorioPersonas.Controllers
{
    public class TelefonoController : Controller
    {
        public ActionResult Index(int PersonaID)
        {
            ViewData["PersonaID"] = PersonaID;

            return PartialView("GridViewTelefono", DataProvider.ObtenerTelefonosPorPersona(PersonaID));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Adicionar(TelefonoVM telefono)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.AdicionarTelefono(telefono);
                }
                catch (Exception e)
                {
                    ViewData["ErroresEdicionTelefono"] = e.Message;
                }
            }
            else
            {
                ViewData["ErroresEdicionTelefono"] = "El formulario contiene errores de validación.";
            }

            return Index(telefono.PersonaID);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Modificar(TelefonoVM telefono)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.ModificarTelefono(telefono);
                }
                catch (Exception e)
                {
                    ViewData["ErroresEdicionTelefonoTelefono"] = e.Message;
                }
            }
            else
            {
                ViewData["ErroresEdicionTelefonoTelefono"] = "El formulario contiene errores de validación.";
            }

            return Index(telefono.PersonaID);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Eliminar(int telefonoID)
        {
            var personaID = -1;

            try
            {
                personaID = DataProvider.EliminarTelefono(telefonoID);
            }
            catch (Exception e)
            {
                ViewData["ErroresEdicionTelefono"] = e.Message;
            }

            return Index(personaID);
        }
    }
}