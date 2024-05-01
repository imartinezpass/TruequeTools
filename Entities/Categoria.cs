using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Categoria" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("categorias")]

    public class Categoria
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

    }

}
