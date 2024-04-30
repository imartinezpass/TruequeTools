using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para el form de inicio de sesion
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{

	public class LoginViewModel
	{

        [Required(ErrorMessage = "Debe ingresar su correo electronico")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico valido")]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; } = "";

    }

}
