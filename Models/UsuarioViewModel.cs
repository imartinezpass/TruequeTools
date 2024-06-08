using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para los form de alta y modificacion de sucrusales
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
	public class UsuarioViewModel
	{
		[Required(ErrorMessage = "Debe ingresar el nombre del usuario.")]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar el apellido del usuario.")]
		[Display(Name = "Apellido")]
		public string Direccion { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar la Fecha de nacimiento.")]
		[Display(Name = "FechaNacimiento")]
		public string Localidad { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar una sucursal.")]
		[Display(Name = "Sucursal")]
		public string Localidad { get; set; } = "";
	}
}
