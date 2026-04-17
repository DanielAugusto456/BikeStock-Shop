using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_negocio
{
    public class LogicaUsuarios
    {
        Datos.UserRepository repositorio = new Datos.UserRepository();

        public void IngresarUsuario(string username, string password, int rol)
        {
            repositorio.IngresarUsuario(username, password, rol);
        }

        public Datos.UserRepository.Usuario ValidarUsuario(string username, string password)
        {
            return repositorio.ValidarUsuario(username, password);
        }

        public void ActualizarUsuario(int id, string username, string password, int rol)
        {
            repositorio.ActualizarUsuario(id, username, password, rol);
        }

        public void EliminarUsuario(int id)
        {
            repositorio.EliminarUsuario(id);
        }

        public List<Datos.UserRepository.Usuario> BuscarUsuarios(string nombre) 
        {
            return repositorio.BuscarUsuarios(nombre);
        }
    }
}
