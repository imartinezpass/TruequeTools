using TruequeTools.Data;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosImagen"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Imagen"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosImagen(TruequeToolsDataContext context) : IServiciosImagen
    {

        private readonly TruequeToolsDataContext contexto = context;

        public async Task AltaImagenes(List<Imagen> imagenes)
        {
            foreach (Imagen i in imagenes)
            {
                contexto.Imagenes.Add(i);
                await contexto.SaveChangesAsync();
            }
        }

    }

}
