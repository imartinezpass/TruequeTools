using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para el form de alta de publicacion
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
    public class PublicacionViewModel()
    {
        [Required(ErrorMessage = "El nombre debe tener al menos 6 caracteres.")]
        [MinLength(6, ErrorMessage = "El nombre debe tener al menos 6 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La descripcion debe tener al menos 20 caracteres.")]
        [MinLength(20, ErrorMessage = "La descripcion debe tener al menos 20 caracteres.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = "";

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; } = 1;

        [Range(1, 3, ErrorMessage = "La categoría debe ser seleccionada.")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } = 0;

        public string? FotoUrl { get; set; }

        [Range(0, 1024*1024*5, ErrorMessage = "Imagen demasiado grande(5MB máximo), seleccione otra si lo desea.")]
        public long FileSize { get; set; } = 0;
    }
}
