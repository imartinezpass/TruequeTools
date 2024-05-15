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

        //DATOS INGRESADOS POR EL USUARIO

        [Column("productoNombre")]
        [MaxLength(50)]
        public string? ProductoNombre { get; set; }

        [Column("productoDescripcion")]
        [MaxLength(50)]
        public string? ProductoDescripcion { get; set; }

        [Column("productoFotoUrl")]
        [MaxLength(255)]
        public string? ProductoFotoUrl { get; set; }

        //CLAVE EXTERNA USUARIO

        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        //CLAVE EXTERNA PUBLICACION

        [Column("publicacionId")]
        public int PublicacionId { get; set; }

        //ATRIBUTOS NO SQL

        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }

    }

}