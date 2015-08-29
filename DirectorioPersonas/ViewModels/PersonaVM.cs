using System;
using System.ComponentModel.DataAnnotations;

namespace DirectorioPersonas.ViewModels
{
    public class PersonaVM
    {
        [Key]
        public int PersonaID { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public DateTime FechaNacimiento { get; set; }
        public byte[] Fotografia { get; set; }
    }
}