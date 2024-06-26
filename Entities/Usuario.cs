﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Usuario" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("usuarios")]

    public class Usuario
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO

        [Column("nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = "Nombre";

        [Column("apellido")]
        [MaxLength(50)]
        public string? Apellido { get; set; }

        [Column("email")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Column("contraseña")]
        [MaxLength(50)]
        public string? Contraseña { get; set; }

        [Column("fechaNacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        //METADATA

        [Column("rol")]
        public string Rol { get; set; } = "User";

        //CLAVES EXTERNAS

        [Column("sucursalId")]
        public int SucursalId { get; set; }

		//MARCA DE BORRADO LOGICO

		[Column("deleted")]
		public bool Deleted { get; set; } = false;

		//ATRIBUTOS NO SQL - FOREGIN KEY FIELDS

		public Sucursal? Sucursal { get; set; }

        //ATRIBUTOS NO SQL - REVERSE RELATIONSHIP FIELDS

        public ICollection<Publicacion>? Publicaciones { get; set; }
		public ICollection<Oferta>? Ofertas { get; set; }
		public ICollection<Pregunta>? Preguntas { get; set; }

	}

}
