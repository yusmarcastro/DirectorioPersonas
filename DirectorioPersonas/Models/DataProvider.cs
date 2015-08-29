using System;
using System.Collections;
using System.Linq;
using System.Web;
using DirectorioPersonas.ViewModels;

namespace DirectorioPersonas.Models {

    public static class DataProvider {

        const string ContextKey = "DataContext";

        public static DirectorioTelefonico Context {
            get {

                if (HttpContext.Current.Items[ContextKey] == null)
                    HttpContext.Current.Items[ContextKey] = new DirectorioTelefonico();

                return (DirectorioTelefonico)HttpContext.Current.Items[ContextKey];
            }
        }

        // Personas
        public static IEnumerable ObtenerPersonas()
        {
            return Context.Personas.ToList();
        }

        public static void EliminarPersona(int id)
        {
            var persona = Context.Personas.Single(p => p.PersonaID == id);

            Context.Personas.Remove(persona);

            Context.SaveChanges();
        }

        public static void ModificarPersona(PersonaVM modelo)
        {
            var persona = Context.Personas.SingleOrDefault(p => p.PersonaID == modelo.PersonaID);

            if (persona == null)
                throw new Exception("No se encuentra la persona en la base de datos.");

            persona.Fotografia = modelo.Fotografia;
            persona.Nombre = modelo.Nombre;
            persona.FechaNacimiento = modelo.FechaNacimiento;

            Context.SaveChanges();
        }

        public static void AdicionarPersona(PersonaVM modelo)
        {
            Context.Personas.Add(new Persona
            {
                Fotografia = modelo.Fotografia,
                Nombre = modelo.Nombre,
                FechaNacimiento = modelo.FechaNacimiento
            });

            Context.SaveChanges();
        }

        // Teléfonos
        public static IEnumerable ObtenerTelefonosPorPersona(int personaID)
        {
            return Context.Telefonoes.Where(t => t.PersonaID == personaID).ToList();
        }

        public static int EliminarTelefono(int id)
        {
            var telefono = Context.Telefonoes.Single(p => p.TelefonoID == id);

            Context.Telefonoes.Remove(telefono);

            Context.SaveChanges();

            return telefono.PersonaID;
        }

        public static void ModificarTelefono(TelefonoVM modelo)
        {
            var telefono = Context.Telefonoes.SingleOrDefault(p => p.TelefonoID == modelo.TelefonoID);

            if (telefono == null)
                throw new Exception("No se encuentra el teléfono en la base de datos.");

            telefono.Numero = modelo.Numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            telefono.PersonaID = modelo.PersonaID;

            Context.SaveChanges();
        }

        public static void AdicionarTelefono(TelefonoVM modelo)
        {
            Context.Telefonoes.Add(new Telefono
            {
                Numero = modelo.Numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""),
                PersonaID = modelo.PersonaID
            });

            Context.SaveChanges();
        }
    }
}