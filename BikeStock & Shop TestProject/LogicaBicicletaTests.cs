using System;
using System.Collections.Generic;
using Datos;
using Logica_de_negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeStock.Tests
{
    [TestClass]
    public class LogicaBicicletaTests
    {
        private Mock<IBicicletaRepository> _mockRepositorio;
        private LogicaBicicleta _logicaBicicleta;

        [TestInitialize]
        public void ConfiguracionInicial()
        {
            _mockRepositorio = new Mock<IBicicletaRepository>();

            _logicaBicicleta = new LogicaBicicleta(_mockRepositorio.Object);
        }

        // Pruebas para el método IngresarBicicleta

        [TestMethod]
        public void IngresarBicicleta_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = 499.99m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);

            // Assert
            _mockRepositorio.Verify(
                x => x.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion),
                Times.Once,
                "El método IngresarBicicleta debe llamarse exactamente una vez con los parámetros correctos"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_MarcaVacia_LanzaExcepcion()
        {
            // Arrange
            string marca = "";
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = 499.99m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_MarcaNula_LanzaExcepcion()
        {
            // Arrange
            string marca = null;
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = 499.99m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_ModeloVacio_LanzaExcepcion()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "";
            string color = "Rojo";
            decimal precio = 499.99m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_ColorVacio_LanzaExcepcion()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "Marlin 5";
            string color = "";
            decimal precio = 499.99m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_PrecioCero_LanzaExcepcion()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = 0;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarBicicleta_PrecioNegativo_LanzaExcepcion()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = -100.00m;
            int disponible = 10;
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        public void IngresarBicicleta_DisponibleNegativo_InvocaRepositorioConValorNegativo()
        {
            // Arrange
            string marca = "Trek";
            string modelo = "Marlin 5";
            string color = "Rojo";
            decimal precio = 499.99m;
            int disponible = -5; // Valor negativo permitido por la lógica
            int reparacion = 0;

            // Act
            _logicaBicicleta.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion);

            // Assert
            _mockRepositorio.Verify(
                x => x.IngresarBicicleta(marca, modelo, color, precio, disponible, reparacion),
                Times.Once
            );
        }

        // Pruebas para el método ObtenerBicicletas

        [TestMethod]
        public void ObtenerBicicletas_SinParametros_RetornaTodasLasBicicletas()
        {
            // Arrange
            var bicicletasEsperadas = new List<BicecletasRepository.Bicicleta>
            {
                new BicecletasRepository.Bicicleta { Id = 1, Marca = "Trek", Modelo = "Marlin 5", Color = "Rojo", Precio = 499.99m, Disponible = 10, Reparacion = 0 },
                new BicecletasRepository.Bicicleta { Id = 2, Marca = "Specialized", Modelo = "Allez", Color = "Negro", Precio = 899.99m, Disponible = 5, Reparacion = 1 },
                new BicecletasRepository.Bicicleta { Id = 3, Marca = "Giant", Modelo = "Escape 3", Color = "Azul", Precio = 399.99m, Disponible = 8, Reparacion = 0 }
            };

            _mockRepositorio
                .Setup(x => x.ObtenerBicicletas(null, null, null))
                .Returns(bicicletasEsperadas);

            // Act
            var resultado = _logicaBicicleta.ObtenerBicicletas();

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(3, resultado.Count, "Deben retornarse 3 bicicletas");
            Assert.AreEqual("Trek", resultado[0].Marca);
            Assert.AreEqual("Specialized", resultado[1].Marca);
            Assert.AreEqual("Giant", resultado[2].Marca);
        }

        [TestMethod]
        public void ObtenerBicicletas_PorMarca_RetornaBicicletasFiltradas()
        {
            // Arrange
            string marcaFiltro = "Trek";
            var bicicletasFiltradas = new List<BicecletasRepository.Bicicleta>
            {
                new BicecletasRepository.Bicicleta { Id = 1, Marca = "Trek", Modelo = "Marlin 5", Color = "Rojo", Precio = 499.99m, Disponible = 10, Reparacion = 0 },
                new BicecletasRepository.Bicicleta { Id = 4, Marca = "Trek", Modelo = "Domane", Color = "Verde", Precio = 1299.99m, Disponible = 3, Reparacion = 0 }
            };

            _mockRepositorio
                .Setup(x => x.ObtenerBicicletas(marcaFiltro, null, null))
                .Returns(bicicletasFiltradas);

            // Act
            var resultado = _logicaBicicleta.ObtenerBicicletas(marca: marcaFiltro);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(2, resultado.Count, "Deben encontrarse 2 bicicletas Trek");
            Assert.IsTrue(resultado.TrueForAll(b => b.Marca == "Trek"), "Todas las bicicletas deben ser de la marca Trek");
        }

        [TestMethod]
        public void ObtenerBicicletas_PorMarcaYModelo_RetornaBicicletasFiltradas()
        {
            // Arrange
            string marcaFiltro = "Trek";
            string modeloFiltro = "Marlin 5";
            var bicicletasFiltradas = new List<BicecletasRepository.Bicicleta>
            {
                new BicecletasRepository.Bicicleta { Id = 1, Marca = "Trek", Modelo = "Marlin 5", Color = "Rojo", Precio = 499.99m, Disponible = 10, Reparacion = 0 }
            };

            _mockRepositorio
                .Setup(x => x.ObtenerBicicletas(marcaFiltro, modeloFiltro, null))
                .Returns(bicicletasFiltradas);

            // Act
            var resultado = _logicaBicicleta.ObtenerBicicletas(marca: marcaFiltro, modelo: modeloFiltro);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(1, resultado.Count, "Debe encontrarse exactamente 1 bicicleta");
            Assert.AreEqual("Trek", resultado[0].Marca);
            Assert.AreEqual("Marlin 5", resultado[0].Modelo);
        }

        [TestMethod]
        public void ObtenerBicicletas_SinCoincidencias_RetornaListaVacia()
        {
            // Arrange
            string marcaFiltro = "MarcaInexistente";

            _mockRepositorio
                .Setup(x => x.ObtenerBicicletas(marcaFiltro, null, null))
                .Returns(new List<BicecletasRepository.Bicicleta>());

            // Act
            var resultado = _logicaBicicleta.ObtenerBicicletas(marca: marcaFiltro);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(0, resultado.Count, "La lista debe estar vacía cuando no hay coincidencias");
        }

        // Pruebas para el método ActualizarBicicleta

        [TestMethod]
        public void ActualizarBicicleta_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;
            string marca = "Trek";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 599.99m;
            int disponible = 8;
            int reparacion = 1;

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);

            // Assert
            _mockRepositorio.Verify(
                x => x.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion),
                Times.Once,
                "El método ActualizarBicicleta debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarBicicleta_IdCero_LanzaExcepcion()
        {
            // Arrange
            int id = 0;
            string marca = "Trek";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 599.99m;
            int disponible = 8;
            int reparacion = 1;

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarBicicleta_IdNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = -1;
            string marca = "Trek";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 599.99m;
            int disponible = 8;
            int reparacion = 1;

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarBicicleta_MarcaVacia_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            string marca = "";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 599.99m;
            int disponible = 8;
            int reparacion = 1;

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarBicicleta_PrecioCero_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            string marca = "Trek";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 0;
            int disponible = 8;
            int reparacion = 1;

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ActualizarBicicleta_IdNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;
            string marca = "Trek";
            string modelo = "Marlin 6";
            string color = "Azul";
            decimal precio = 599.99m;
            int disponible = 8;
            int reparacion = 1;

            _mockRepositorio
                .Setup(x => x.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaBicicleta.ActualizarBicicleta(id, marca, modelo, color, precio, disponible, reparacion);
        }

        // Pruebas para el método EliminarBicicleta

        [TestMethod]
        public void EliminarBicicleta_IdValido_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;

            // Act
            _logicaBicicleta.EliminarBicicleta(id);

            // Assert
            _mockRepositorio.Verify(
                x => x.EliminarBicicleta(id),
                Times.Once,
                "El método EliminarBicicleta debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarBicicleta_IdCero_LanzaExcepcion()
        {
            // Arrange
            int id = 0;

            // Act
            _logicaBicicleta.EliminarBicicleta(id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarBicicleta_IdNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = -5;

            // Act
            _logicaBicicleta.EliminarBicicleta(id);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void EliminarBicicleta_IdNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;

            _mockRepositorio
                .Setup(x => x.EliminarBicicleta(id))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaBicicleta.EliminarBicicleta(id);
        }

        // Pruebas para el método ActualizarStock

        [TestMethod]
        public void ActualizarStock_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;
            int disponible = 15;
            int reparacion = 2;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);

            // Assert
            _mockRepositorio.Verify(
                x => x.ActualizarStock(id, disponible, reparacion),
                Times.Once,
                "El método ActualizarStock debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarStock_IdCero_LanzaExcepcion()
        {
            // Arrange
            int id = 0;
            int disponible = 15;
            int reparacion = 2;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarStock_IdNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = -1;
            int disponible = 15;
            int reparacion = 2;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarStock_DisponibleNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            int disponible = -5;
            int reparacion = 2;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarStock_ReparacionNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            int disponible = 15;
            int reparacion = -3;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);
        }

        [TestMethod]
        public void ActualizarStock_DisponibleCero_InvocaRepositorio()
        {
            // Arrange
            int id = 1;
            int disponible = 0;
            int reparacion = 0;

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);

            // Assert
            _mockRepositorio.Verify(
                x => x.ActualizarStock(id, disponible, reparacion),
                Times.Once,
                "Stock cero es un valor válido y debe permitirse"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ActualizarStock_IdNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;
            int disponible = 10;
            int reparacion = 0;

            _mockRepositorio
                .Setup(x => x.ActualizarStock(id, disponible, reparacion))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaBicicleta.ActualizarStock(id, disponible, reparacion);
        }
    }
}
