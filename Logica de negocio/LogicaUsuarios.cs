using System;
using System.Collections.Generic;
using Datos;

namespace Logica_de_negocio
{
    public class LogicaUsuarios
    {
        private readonly IUserRepository _repositorio;

        public LogicaUsuarios(IUserRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public LogicaUsuarios() : this(new UserRepository())
        {
        }

        public void IngresarUsuario(string username, string password, int rol)
        {
            _repositorio.IngresarUsuario(username, password, rol);
        }

        public UserRepository.Usuario ValidarUsuario(string username, string password)
        {
            return _repositorio.ValidarUsuario(username, password);
        }

        public void ActualizarUsuario(int id, string username, string password, int rol)
        {
            _repositorio.ActualizarUsuario(id, username, password, rol);
        }

        public void EliminarUsuario(int id)
        {
            _repositorio.EliminarUsuario(id);
        }

        public List<UserRepository.Usuario> BuscarUsuarios(string nombre)
        {
            return _repositorio.BuscarUsuarios(nombre);
        }
    }
}
