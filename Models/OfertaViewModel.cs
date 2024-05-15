using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para el form de oferta
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
    public class OfertaViewModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(6, ErrorMessage = "El nombre debe tener al menos 6 caracteres.")]
        [Display(Name = "Nombre")]
        public string ProductoNombre { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar una descripción del producto")]
        [MinLength(20, ErrorMessage = "La descripción debe tener al menos 20 caracteres.")]
        [Display(Name = "Descripción")]
        public string ProductoDescripcion { get; set; } = "";
    }
}
