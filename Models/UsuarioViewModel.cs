using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para los form de alta y modificacion de sucrusales
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
	public class UsuarioViewModel
	{
		[Required(ErrorMessage = "Debe ingresar su nombre")]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar su apellido")]
		[Display(Name = "Apellido")]
		public string Apellido { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar su fecha de nacimiento")]
		[Display(Name = "Fecha de Nacimiento")]
		public DateOnly FechaNacimiento { get; set; } = DateOnly.FromDateTime(DateTime.Today).AddYears(-18);

		[Required(ErrorMessage = "Debe ingresar una sucrusal de preferencia")]
		[Display(Name = "Sucrusal")]
		public int SucursalId { get; set; } = 1;
	}
}
