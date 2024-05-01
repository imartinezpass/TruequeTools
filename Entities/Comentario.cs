using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Comentario" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("comentarios")]

    public class Comentario
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("texto")]
        [MaxLength(255)]
        public string? Texto { get; set; }

        //RELACION CON LA TABLA COMENTARIOS

        [Column("respuestaId")]
        public int? RespuestaId { get; set; }

        //ATRIBUTOS NO SQL

        public string? Respuesta { get; set; }

    }

}

