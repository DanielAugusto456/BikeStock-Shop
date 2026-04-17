using System;
using System.Collections.Generic;
using Datos;

namespace Logica_de_negocio
{
    public class LogicaBicicleta
    {
        private readonly IBicicletaRepository _repositorio;

        public LogicaBicicleta(IBicicletaRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public LogicaBicicleta() : this(new BicecletasRepository())
        {
        }

        public void IngresarBicicleta(string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            ValidarDatosBicicleta(marca, modelo, color, precio);
            _repositorio.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        public List<BicecletasRepository.Bicicleta> ObtenerBicicletas(string marca = null, string modelo = null, string color = null)
        {
            return _repositorio.ObtenerBicicletas(marca, modelo, color);
        }

        public void ActualizarBicicleta(int id, string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            ValidarDatosBicicleta(marca, modelo, color, precio);
            _repositorio.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        public void EliminarBicicleta(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            _repositorio.EliminarBicicleta(id);
        }

        public void ActualizarStock(int id, int disponible, int reparacion)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            if (disponible < 0)
                throw new ArgumentException("El stock disponible no puede ser negativo", nameof(disponible));

            if (reparacion < 0)
                throw new ArgumentException("El stock en reparación no puede ser negativo", nameof(reparacion));

            _repositorio.ActualizarStock(id, disponible, reparacion);
        }

        private void ValidarDatosBicicleta(string marca, string modelo, string color, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca no puede estar vacía", nameof(marca));

            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo no puede estar vacío", nameof(modelo));

            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("El color no puede estar vacío", nameof(color));

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero", nameof(precio));
        }
    }
}