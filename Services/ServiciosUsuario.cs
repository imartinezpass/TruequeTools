using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosUsuario"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Usuario"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosUsuario(TruequeToolsDataContext context) : IServiciosUsuario
    {

        private readonly TruequeToolsDataContext contexto = context;

        //RECIBE UN USUARIO COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
        public async Task RegisterUsuario(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            await contexto.SaveChangesAsync();
        }

        //RECIBE UN CORREO ELECTRONICO Y DEVUELVE SI SE ENCUENTRA REGISTRADO O NO
        public async Task<bool> SeEncuentraRegistrado(string email)
        {
            var usuarioExistente = await contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            return usuarioExistente != null;
        }

    }

}
