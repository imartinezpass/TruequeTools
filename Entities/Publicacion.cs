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

        [Column("titulo")]
        [MaxLength(50)]
        public string? Titulo { get; set; }

        //METADATA

        [Column("isPremium")]
        public bool IsPremium { get; set; } = false;

        [Column("isOculta")]
        public bool IsOculta { get; set; } = false;

        [Column("fechaPublicacion")]
        public DateOnly FechaPublicacion { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //RELACION CON LA TABLA USUARIOS

        /*[Column("usuarioId")]
        public int UsuarioId { get; set; }*/

        //RELACION CON LA TABLA SUCURSALES

        [Column("sucursalId")]
        public int SucursalId { get; set; }

        //RELACION CON LA TABLA PRODUCTOS

        [Column("productoId")]
        public int ProductoId { get; set; }

        //RELACION CON LA TABLA COMENTARIOS

        [Column("comentariosId")]
        public int ComentariosId { get; set; } 

        //ATRIBUTOS NO SQL

        public Usuario? Usuario { get; set; }
        public Sucursal? Sucursal { get; set; }
        public Producto? Producto { get; set; }
        public List<Comentario>? Comentarios { get; set; }

    }

}
