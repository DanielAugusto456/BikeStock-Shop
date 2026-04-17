using System;
using System.Collections.Generic;
using Datos;

namespace Logica_de_negocio
{
    public class LogicaAccesorios
    {
        private readonly IAccesoriosRepository _repositorio;

        public LogicaAccesorios(IAccesoriosRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public LogicaAccesorios() : this(new AccesoriosRepository())
        {
        }

        public List<AccesoriosRepository.Accesorio> BuscarAccesorios(string nombre, string tipo, string marca)
        {
            return _repositorio.BuscarAccesorios(nombre, tipo, marca);
        }

        public void InsertarAccesorio(string nombre, string tipo, string marca, decimal precio, int stock)
        {
            ValidarDatosAccesorio(nombre, tipo, marca, precio, stock);
            _repositorio.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        public void ActualizarAccesorio(int id, string nombre, string tipo, string marca, decimal precio, int stock)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            ValidarDatosAccesorio(nombre, tipo, marca, precio, stock);
            _repositorio.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        public void EliminarAccesorio(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            _repositorio.EliminarAccesorio(id);
        }

        // Método privado para validaciones comunes
        private void ValidarDatosAccesorio(string nombre, string tipo, string marca, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del accesorio no puede estar vacío", nameof(nombre));

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo del accesorio no puede estar vacío", nameof(tipo));

            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca del accesorio no puede estar vacía", nameof(marca));

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero", nameof(precio));

            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo", nameof(stock));
        }
    }
}
