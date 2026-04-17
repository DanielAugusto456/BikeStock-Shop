using System.Collections.Generic;

namespace Datos
{
    public interface IBicicletaRepository
    {
        void IngresarBicicleta(string marca, string modelo, string color, decimal precio, int disponible, int reparacion);
        List<BicecletasRepository.Bicicleta> ObtenerBicicletas(string marca = null, string modelo = null, string color = null);
        void ActualizarBicicleta(int id, string marca, string modelo, string color, decimal precio, int disponible, int reparacion);
        void EliminarBicicleta(int id);
        void ActualizarStock(int id, int disponible, int reparacion);
    }
}