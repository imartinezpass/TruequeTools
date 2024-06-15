using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Producto" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("productos")]

    public class Producto
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("nombre")]
        public string? Nombre { get; set; }

		[Column("cantidad")]
		public int Cantidad { get; set; }

		[Column("monto")]
        public double Monto { get; set; }

        //CLAVES EXTERNAS

        [Column("truequeId")]
        public int TruequeId { get; set; }

    }

}
