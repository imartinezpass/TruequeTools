using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Imagen" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("imagenes")]

    public class Imagen
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //METADATA

        [Column("fotoUrl")]
        public string? FotoUrl { get; set; }

        //CLAVES EXTERNAS

        [Column("publicacionId")]
        public int PublicacionId { get; set; }

    }

}