using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para el form de alta de publicacion
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
    public class PublicacionViewModel()
    {
        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(4, ErrorMessage = "El nombre debe tener al menos 4 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar una descripción del producto")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = "";

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; } = 1;

        [Range(1, 3, ErrorMessage = "Seleccione una categoria valida")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } = 0;
    }
}
