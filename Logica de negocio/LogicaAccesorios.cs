using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_negocio
{
    public class LogicaAccesorios
    {
        Datos.AccesoriosRepository repositorio = new Datos.AccesoriosRepository();

        public List<Datos.AccesoriosRepository.Accesorio> BuscarAccesorios(string nombre, string tipo, string marca)
        {
            return repositorio.BuscarAccesorios(nombre, tipo, marca);
        }

        public void InsertarAccesorio(string nombre, string tipo, string marca, decimal precio, int stock)
        {
            repositorio.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        public void ActualizarAccesorio(int id, string nombre, string tipo, string marca, decimal precio, int stock)
        {
            repositorio.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        public void EliminarAccesorio(int id)
        {
            repositorio.EliminarAccesorio(id);
        }
    }
}
