using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
    public class MotivoViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un motivo")]
        [Display(Name = "Elija un motivo")]
        public string Motivo { get; set; } = "";
    }
}
