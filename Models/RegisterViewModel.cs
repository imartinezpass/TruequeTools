using System.ComponentModel.DataAnnotations;

/*
  
Esta clase establece los campos, restricciones y mensajes de error para el form de registro
Tambien realiza las verificaciones de input
  
 */

namespace TruequeTools.Models
{
    public class RegisterViewModel
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

	    [Required(ErrorMessage = "Debe ingresar su correo electronico")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico valido")]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; } = "";

        [Required(ErrorMessage = "La contraseña debe tener al menos un caracter alfanumérico, un número, una mayúscula y un caracter especial con un minimo de 6 caracteres.")]
        [StringLength(50, ErrorMessage = "La contraseña debe tener al menos un caracter alfanumérico, un número, una mayúscula y un caracter especial con un minimo de 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage = "La contraseña debe tener al menos un caracter alfanumérico, un número, una mayúscula y un caracter especial con un minimo de 6 caracteres.")]
        public string Contraseña { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContraseña { get; set; } = "";
    }
}
