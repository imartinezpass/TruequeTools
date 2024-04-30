/*
 
Esta clase establece la entidad "Producto" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    public class Producto
    {

        //ID UNIVOCO
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public byte[]? Foto { get; set; }
        
    }

}
