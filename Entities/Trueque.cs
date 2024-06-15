using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Trueque" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("trueques")]

    public class Trueque
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //METADATA

        [Column("estado")]
        public int Estado { get; set; } = 0; //0 pendiente, -1 no concretado, 1 concretado

        [Column("hasVentas")]
        public bool HasVentas { get; set; } = false;

        [Column("cargaCompleted")]
        public bool CargaCompleted { get; set; } = false;

        //CLAVES EXTERNAS

        [Column("ofertaId")]
        public int OfertaId { get; set; }

        //ATRIBUTOS NO SQL - FOREGIN KEY FIELDS

        public Oferta? Oferta { get; set; }

        //REVERSE RELATIONSHIP

        public List<Producto>? Productos { get; set; }
    }

}