using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
	public class RespuestaViewModel
	{
		[Required(ErrorMessage = "La respuesta debe tener al menos 10 caracteres")]
		[MinLength(10, ErrorMessage = "La respuesta debe tener al menos 10 caracteres")]
		[Display(Name = "Escriba su respuesta")]
		public string Respuesta { get; set; } = "";
	}
}
