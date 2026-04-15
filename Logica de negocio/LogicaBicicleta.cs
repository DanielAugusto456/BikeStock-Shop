using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_negocio
{
    public class LogicaBicicleta
    {
        Datos.BicecletasRepository repositorio = new Datos.BicecletasRepository();
        public void IngresarBicicleta(string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            repositorio.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }
        public List<Datos.BicecletasRepository.Bicicleta> ObtenerBicicletas(string marca = null, string modelo = null, string color = null)
        {
            return repositorio.ObtenerBicicletas(marca, modelo, color);
        }

        public void ActualizarBicicleta(int id, string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            repositorio.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        public void EliminarBicicleta(int id)
        {
            repositorio.EliminarBicicleta(id);
        }
    }
}
