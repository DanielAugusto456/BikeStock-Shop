using System.Collections.Generic;

namespace Datos
{
    public interface IUserRepository
    {
        void IngresarUsuario(string username, string password, int rol);
        UserRepository.Usuario ValidarUsuario(string username, string password);
        void ActualizarUsuario(int id, string username, string password, int rol);
        void EliminarUsuario(int id);
        List<UserRepository.Usuario> BuscarUsuarios(string nombre);
    }
}