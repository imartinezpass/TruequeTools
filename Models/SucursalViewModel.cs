using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para los form de alta y modificacion de sucrusales
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
	public class SucursalViewModel
	{
		[Required(ErrorMessage = "Debe ingresar el nombre de la sucursal")]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar la direccion de la sucursal")]
		[Display(Name = "Direccion")]
		public string Direccion { get; set; } = "";

		[Required(ErrorMessage = "Debe ingresar la localidad de la sucursal")]
		[Display(Name = "Localidad")]
		public string Localidad { get; set; } = "";
	}
}
