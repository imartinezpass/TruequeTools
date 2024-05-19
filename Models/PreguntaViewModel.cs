using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
	public class PreguntaViewModel
	{
		[Required(ErrorMessage = "La pregunta no puede estar vacía")]
		[MinLength(10, ErrorMessage = "La pregunta debe tener al menos 10 caracteres")]
		[Display(Name = "Escriba su pregunta")]
		public string Pregunta { get; set; } = "";
	}
}
