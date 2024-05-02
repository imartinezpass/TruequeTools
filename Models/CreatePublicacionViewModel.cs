using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
    public class CreatePublicacionViewModel
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

        [Required(ErrorMessage = "Debe seleccionar una catgoría")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } = 1;
    }
}
