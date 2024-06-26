using System.ComponentModel.DataAnnotations;

namespace TruequeTools.Models
{
    public class TarjetaViewModel
    {
        [Required(ErrorMessage = "Debe el número de la tarjeta")]
        [Display(Name = "Numero de tarjeta")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Ingrese una tarjeta de crédito válida.")]
        public double NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del titular")]
        [Display(Name = "Nombre de titular")]
        public string NombreTitular { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar el año de vencimiento")]
        [Display(Name = "Año de vencimiento")]
        public int AñoVencimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar el mes de vencimiento")]
        [Display(Name = "Mes de vencimiento")]
        public int MesVencimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar un CVC válido")]
        [Display(Name = "CVC")]
        public int CVC { get; set; }
    }
}
