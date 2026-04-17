using System;
using System.Collections.Generic;
using Datos;
using Logica_de_negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeStock.Tests
{
    [TestClass]
    public class LogicaAccesoriosTests
    {
        private Mock<IAccesoriosRepository> _mockRepositorio;
        private LogicaAccesorios _logicaAccesorios;

        [TestInitialize]
        public void ConfiguracionInicial()
        {
            _mockRepositorio = new Mock<IAccesoriosRepository>();

            _logicaAccesorios = new LogicaAccesorios(_mockRepositorio.Object);
        }

        // Pruebas para el método BuscarAccesorios

        [TestMethod]
        public void BuscarAccesorios_SinParametros_RetornaTodosLosAccesorios()
        {
            // Arrange
            var accesoriosEsperados = new List<AccesoriosRepository.Accesorio>
            {
                new AccesoriosRepository.Accesorio { Id = 1, Nombre = "Casco Urbano", tipo = "Casco", Marca = "Bell", Precio = 49.99m, Stock = 15 },
                new AccesoriosRepository.Accesorio { Id = 2, Nombre = "Candado", tipo = "Seguridad", Marca = "Abus", Precio = 29.99m, Stock = 20 },
                new AccesoriosRepository.Accesorio { Id = 3, Nombre = "Luz Delantera", tipo = "Iluminación", Marca = "Sigma", Precio = 19.99m, Stock = 10 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(null, null, null))
                .Returns(accesoriosEsperados);

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(null, null, null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(3, resultado.Count, "Deben retornarse 3 accesorios");
            Assert.AreEqual("Casco Urbano", resultado[0].Nombre);
            Assert.AreEqual("Candado", resultado[1].Nombre);
            Assert.AreEqual("Luz Delantera", resultado[2].Nombre);
        }

        [TestMethod]
        public void BuscarAccesorios_PorNombre_RetornaAccesoriosFiltrados()
        {
            // Arrange
            string nombreFiltro = "Casco";
            var accesoriosFiltrados = new List<AccesoriosRepository.Accesorio>
            {
                new AccesoriosRepository.Accesorio { Id = 1, Nombre = "Casco Urbano", tipo = "Casco", Marca = "Bell", Precio = 49.99m, Stock = 15 },
                new AccesoriosRepository.Accesorio { Id = 4, Nombre = "Casco Ruta", tipo = "Casco", Marca = "Giro", Precio = 89.99m, Stock = 8 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(nombreFiltro, null, null))
                .Returns(accesoriosFiltrados);

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(nombre: nombreFiltro, tipo: null, marca: null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(2, resultado.Count, "Deben encontrarse 2 cascos");
            Assert.IsTrue(resultado.TrueForAll(a => a.Nombre.Contains("Casco")), "Todos deben contener 'Casco' en el nombre");
        }

        [TestMethod]
        public void BuscarAccesorios_PorTipo_RetornaAccesoriosFiltrados()
        {
            // Arrange
            string tipoFiltro = "Seguridad";
            var accesoriosFiltrados = new List<AccesoriosRepository.Accesorio>
            {
                new AccesoriosRepository.Accesorio { Id = 2, Nombre = "Candado", tipo = "Seguridad", Marca = "Abus", Precio = 29.99m, Stock = 20 },
                new AccesoriosRepository.Accesorio { Id = 5, Nombre = "Cadena", tipo = "Seguridad", Marca = "Kryptonite", Precio = 49.99m, Stock = 12 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(null, tipoFiltro, null))
                .Returns(accesoriosFiltrados);

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(nombre: null, tipo: tipoFiltro, marca: null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(2, resultado.Count, "Deben encontrarse 2 accesorios de seguridad");
            Assert.IsTrue(resultado.TrueForAll(a => a.tipo == "Seguridad"), "Todos deben ser de tipo Seguridad");
        }

        [TestMethod]
        public void BuscarAccesorios_PorMarca_RetornaAccesoriosFiltrados()
        {
            // Arrange
            string marcaFiltro = "Bell";
            var accesoriosFiltrados = new List<AccesoriosRepository.Accesorio>
            {
                new AccesoriosRepository.Accesorio { Id = 1, Nombre = "Casco Urbano", tipo = "Casco", Marca = "Bell", Precio = 49.99m, Stock = 15 },
                new AccesoriosRepository.Accesorio { Id = 6, Nombre = "Guantes", tipo = "Protección", Marca = "Bell", Precio = 24.99m, Stock = 25 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(null, null, marcaFiltro))
                .Returns(accesoriosFiltrados);

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(nombre: null, tipo: null, marca: marcaFiltro);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(2, resultado.Count, "Deben encontrarse 2 accesorios de la marca Bell");
            Assert.IsTrue(resultado.TrueForAll(a => a.Marca == "Bell"), "Todos deben ser de la marca Bell");
        }

        [TestMethod]
        public void BuscarAccesorios_PorNombreYTipo_RetornaAccesoriosFiltrados()
        {
            // Arrange
            string nombreFiltro = "Casco";
            string tipoFiltro = "Casco";
            var accesoriosFiltrados = new List<AccesoriosRepository.Accesorio>
            {
                new AccesoriosRepository.Accesorio { Id = 1, Nombre = "Casco Urbano", tipo = "Casco", Marca = "Bell", Precio = 49.99m, Stock = 15 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(nombreFiltro, tipoFiltro, null))
                .Returns(accesoriosFiltrados);

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(nombre: nombreFiltro, tipo: tipoFiltro, marca: null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(1, resultado.Count, "Debe encontrarse exactamente 1 accesorio");
            Assert.AreEqual("Casco Urbano", resultado[0].Nombre);
            Assert.AreEqual("Casco", resultado[0].tipo);
        }

        [TestMethod]
        public void BuscarAccesorios_SinCoincidencias_RetornaListaVacia()
        {
            // Arrange
            string nombreFiltro = "AccesorioInexistente";

            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(nombreFiltro, null, null))
                .Returns(new List<AccesoriosRepository.Accesorio>());

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(nombre: nombreFiltro, tipo: null, marca: null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(0, resultado.Count, "La lista debe estar vacía cuando no hay coincidencias");
        }

        [TestMethod]
        public void BuscarAccesorios_ConParametrosNulos_PasaAlRepositorio()
        {
            // Arrange
            _mockRepositorio
                .Setup(x => x.BuscarAccesorios(null, null, null))
                .Returns(new List<AccesoriosRepository.Accesorio>());

            // Act
            var resultado = _logicaAccesorios.BuscarAccesorios(null, null, null);

            // Assert
            _mockRepositorio.Verify(
                x => x.BuscarAccesorios(null, null, null),
                Times.Once,
                "El método BuscarAccesorios debe llamarse con parámetros nulos"
            );
        }

        // Pruebas para el método InsertarAccesorio

        [TestMethod]
        public void InsertarAccesorio_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);

            // Assert
            _mockRepositorio.Verify(
                x => x.InsertarAccesorio(nombre, tipo, marca, precio, stock),
                Times.Once,
                "El método InsertarAccesorio debe llamarse exactamente una vez con los parámetros correctos"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_NombreVacio_LanzaExcepcion()
        {
            // Arrange
            string nombre = "";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_NombreNulo_LanzaExcepcion()
        {
            // Arrange
            string nombre = null;
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_NombreSoloEspacios_LanzaExcepcion()
        {
            // Arrange
            string nombre = "   ";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_TipoVacio_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_TipoNulo_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = null;
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_MarcaVacia_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_MarcaNula_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = null;
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_PrecioCero_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 0;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_PrecioNegativo_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = -10.00m;
            int stock = 15;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertarAccesorio_StockNegativo_LanzaExcepcion()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = -5;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        public void InsertarAccesorio_StockCero_InvocaRepositorio()
        {
            // Arrange
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 0;

            // Act
            _logicaAccesorios.InsertarAccesorio(nombre, tipo, marca, precio, stock);

            // Assert
            _mockRepositorio.Verify(
                x => x.InsertarAccesorio(nombre, tipo, marca, precio, stock),
                Times.Once,
                "Stock cero es un valor válido y debe permitirse"
            );
        }

        // Pruebas para el método ActualizarAccesorio

        [TestMethod]
        public void ActualizarAccesorio_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;
            string nombre = "Casco Urbano Pro";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 59.99m;
            int stock = 12;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);

            // Assert
            _mockRepositorio.Verify(
                x => x.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock),
                Times.Once,
                "El método ActualizarAccesorio debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarAccesorio_IdCero_LanzaExcepcion()
        {
            // Arrange
            int id = 0;
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarAccesorio_IdNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = -1;
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarAccesorio_NombreVacio_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            string nombre = "";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarAccesorio_PrecioCero_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 0;
            int stock = 15;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarAccesorio_StockNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = 1;
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = -3;

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ActualizarAccesorio_IdNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;
            string nombre = "Casco Urbano";
            string tipo = "Casco";
            string marca = "Bell";
            decimal precio = 49.99m;
            int stock = 15;

            _mockRepositorio
                .Setup(x => x.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaAccesorios.ActualizarAccesorio(id, nombre, tipo, marca, precio, stock);
        }

        // Pruebas para el método EliminarAccesorio

        [TestMethod]
        public void EliminarAccesorio_IdValido_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;

            // Act
            _logicaAccesorios.EliminarAccesorio(id);

            // Assert
            _mockRepositorio.Verify(
                x => x.EliminarAccesorio(id),
                Times.Once,
                "El método EliminarAccesorio debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarAccesorio_IdCero_LanzaExcepcion()
        {
            // Arrange
            int id = 0;

            // Act
            _logicaAccesorios.EliminarAccesorio(id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarAccesorio_IdNegativo_LanzaExcepcion()
        {
            // Arrange
            int id = -5;

            // Act
            _logicaAccesorios.EliminarAccesorio(id);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void EliminarAccesorio_IdNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;

            _mockRepositorio
                .Setup(x => x.EliminarAccesorio(id))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaAccesorios.EliminarAccesorio(id);
        }
    }
}