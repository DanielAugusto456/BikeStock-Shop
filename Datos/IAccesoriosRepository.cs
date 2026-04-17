using System.Collections.Generic;

namespace Datos
{
    public interface IAccesoriosRepository
    {
        List<AccesoriosRepository.Accesorio> BuscarAccesorios(string nombre, string tipo, string marca);
        void InsertarAccesorio(string nombre, string tipo, string marca, decimal precio, int stock);
        void ActualizarAccesorio(int id, string nombre, string tipo, string marca, decimal precio, int stock);
        void EliminarAccesorio(int id);
    }
}