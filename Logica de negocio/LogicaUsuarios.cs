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

        public void IngresarUsuario(string username, string password)
        {
            repositorio.IngresarUsuario(username, password);
        }

        public bool ValidarUsuario(string username, string password)
        {
            return repositorio.ValidarUsuario(username, password);
        }

        public void ActualizarUsuario(int id, string username, string password)
        {
            repositorio.ActualizarUsuario(id, username, password);
        }

        public void EliminarUsuario(int id)
        {
            repositorio.EliminarUsuario(id);
        }
    }
}
