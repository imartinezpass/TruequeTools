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
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [Column("descripcion")]
        [MaxLength(255)]
        [MinLength(20)]
        public string? Descripcion { get; set; }

        [Column("fotoUrl")]
        [MaxLength(255)]
        public string? FotoUrl { get; set; }

        //CLAVE EXTERNA CATEGORIA

        [Column("categoriaId")]
        public int CategoriaId { get; set; }

        //ATRIBUTOS NO SQL

        public Categoria? Categoria { get; set; }

    }

}
