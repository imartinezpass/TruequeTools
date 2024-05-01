using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Sucursal" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("sucursales")]

    public class Sucursal
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("nombre")]
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [Column("direccion")]
        [MaxLength(50)]
        public string? Direccion { get; set; }

        [Column("localidad")]
        [MaxLength(50)]
        public string? Localidad { get; set; }

    }

}
