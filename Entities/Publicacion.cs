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
        public string? Titulo { get; set; }
        public string? Sucursal { get; set; } //ESTO DEBERIA SER EL ID DE LA SUCURSAL
		public int ProductoId { get; set; }
		
		//METADATA
		public int UsuarioId { get; set; }
        public List<int>? ComentarioId { get; set; } //VER POR QUE PINGO NO FUNCIONA
        public bool? IsPremium { get; set; } 
		public bool? IsOculta { get;}
		public DateOnly FechaPublicacion { get; set; }

	}

}
