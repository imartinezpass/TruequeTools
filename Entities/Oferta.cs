using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Oferta" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("ofertas")]

    public class Oferta
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //METADATA

        [Column("estado")] // -1 rechazada, 0 pendiente, 1 aceptada
        public int Estado { get; set; }

        [Column("fecha")] 
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column("motivo")] 
        public string? Motivo { get; set; }

        //CLAVES EXTERNAS

        [Column("usuarioId")] // esto es redundante, lo sacamos con publicacionOfrecidaId usando sql queries
        public int UsuarioId { get; set; }

        [Column("publicacionOfertadaId")]
        public int PublicacionQueOfertoId { get; set; }

        [Column("publicacionOfrecidaId")]
        public int PublicacionQueOfrezcoId { get; set; }

        //ATRIBUTOS NO SQL - FOREGIN KEY FIELDS

        public Usuario? Usuario { get; set; }
        public Publicacion? PublicacionQueOferto { get; set; }
        public Publicacion? PublicacionQueOfrezco { get; set; }

        //ATRIBUTOS NO SQL - REVERSE RELATIONSHIP FIELDS

        public Trueque? Trueque { get; set; }

    }

}