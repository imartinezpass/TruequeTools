using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
    public class OfertaViewModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(4, ErrorMessage = "El nombre debe tener al menos 4 caracteres.")]
        [Display(Name = "Nombre")]
        public string ProductoNombre { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar una descripción del producto")]
        [MinLength(15, ErrorMessage = "La descripción debe tener al menos 15 caracteres.")]
        [Display(Name = "Descripción")]
        public string ProductoDescripcion { get; set; } = "";

        // la foto no es obligatoria
    }
}
