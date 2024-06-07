using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Publicacion" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("publicaciones")]

    public class Publicacion
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

        [Column("descripcion")]
        [MaxLength(255)]
        [MinLength(20)]
        public string? Descripcion { get; set; }

        //METADATA

        [Column("fechaPublicacion")]
        public DateOnly FechaPublicacion { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Column("isPremium")]
        public bool IsPremium { get; set; } = false;

        [Column("hasImages")]
        public bool HasImages { get; set; } = false;

        //CLAVES EXTERNAS

        [Column("categoriaId")]
        public int CategoriaId { get; set; }

        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        [Column("sucursalId")]
        public int SucursalId { get; set; }

		//MARCA DE BORRADO LOGICO

		[Column("deleted")]
		public bool Deleted { get; set; } = false;

		//ATRIBUTOS NO SQL - FOREGIN KEY FIELDS

		public Categoria? Categoria { get; set; }
        public Usuario? Usuario { get; set; }
        public Sucursal? Sucursal { get; set; }

        //ATRIBUTOS NO SQL - REVERSE RELATIONSHIP FIELDS

        public List<Pregunta>? Preguntas { get; set; }
        public List<Imagen>? Imagenes { get; set; }
        public List<Oferta>? OfertasRealizadas { get; set; }
        public List<Oferta>? OfertasRecibidas { get; set; }

    }

}
