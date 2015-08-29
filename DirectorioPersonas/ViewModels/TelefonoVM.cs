using System.ComponentModel.DataAnnotations;

namespace DirectorioPersonas.ViewModels
{
    public class TelefonoVM
    {
        [Key]
        public int TelefonoID { get; set; }

        [Required(ErrorMessage = "Campo requerido."), 
         Phone(ErrorMessage = "Número telefónico inválido.")]
        public string Numero { get; set; }

        public int PersonaID { get; set; }
    }
}