/*
 
Esta clase establece la entidad "Publicacion" y sus atributos
 
 */

namespace TruequeTools.Entities
{

	public class Publicacion
	{

		//ID UNIVOCO
		public int Id { get; set; }

		//DATOS INGRESADOS POR EL USUARIO
		public string? Nombre { get; set; }
		public string? Descripcion { get; set; }
		public string? Sucursal { get; set; }
		public int Categoria { get; set; }
		public byte[]? Foto { get; set; }

		//METADATA
		public int PropietarioId { get; set; }
		public bool? IsPremium { get; set; } 
		public bool? IsOculta { get;}
		public DateOnly FechaPublicacion { get; set; }

	}

}
