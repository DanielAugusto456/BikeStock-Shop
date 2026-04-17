using System;
using System.Collections.Generic;
using Datos;
using Logica_de_negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeStock.Tests
{
    [TestClass]
    public class LogicaUsuariosTests
    {
        private Mock<IUserRepository> _mockRepositorio;
        private LogicaUsuarios _logicaUsuarios;

        [TestInitialize]
        public void ConfiguracionInicial()
        {
            _mockRepositorio = new Mock<IUserRepository>();

            _logicaUsuarios = new LogicaUsuarios(_mockRepositorio.Object);
        }

        // Pruebas para el método IngresarUsuario

        [TestMethod]
        public void IngresarUsuario_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            string username = "juanperez";
            string password = "123456";
            int rol = 1;

            // Act
            _logicaUsuarios.IngresarUsuario(username, password, rol);

            // Assert
            _mockRepositorio.Verify(
                x => x.IngresarUsuario(username, password, rol),
                Times.Once,
                "El método IngresarUsuario debe llamarse exactamente una vez con los parámetros correctos"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IngresarUsuario_UsernameNulo_LanzaExcepcion()
        {
            // Arrange
            string username = null;
            string password = "123456";
            int rol = 1;

            // Configurar el mock para lanzar excepción
            _mockRepositorio
                .Setup(x => x.IngresarUsuario(username, password, rol))
                .Throws<ArgumentNullException>();

            // Act
            _logicaUsuarios.IngresarUsuario(username, password, rol);

            // Assert manejado por ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarUsuario_UsernameVacio_LanzaExcepcion()
        {
            // Arrange
            string username = "";
            string password = "123456";
            int rol = 1;

            _mockRepositorio
                .Setup(x => x.IngresarUsuario(username, password, rol))
                .Throws<ArgumentException>();

            // Act
            _logicaUsuarios.IngresarUsuario(username, password, rol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IngresarUsuario_PasswordVacio_LanzaExcepcion()
        {
            // Arrange
            string username = "juanperez";
            string password = "";
            int rol = 1;

            _mockRepositorio
                .Setup(x => x.IngresarUsuario(username, password, rol))
                .Throws<ArgumentException>();

            // Act
            _logicaUsuarios.IngresarUsuario(username, password, rol);
        }

        // Pruebas para el método ValidarUsuario

        [TestMethod]
        public void ValidarUsuario_CredencialesCorrectas_RetornaUsuario()
        {
            // Arrange
            string username = "admin";
            string password = "123456";

            var usuarioEsperado = new UserRepository.Usuario
            {
                Id = 1,
                Username = "admin",
                Password = "hash_de_contraseña",
                Rol = 1
            };

            _mockRepositorio
                .Setup(x => x.ValidarUsuario(username, password))
                .Returns(usuarioEsperado);

            // Act
            var resultado = _logicaUsuarios.ValidarUsuario(username, password);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo para credenciales correctas");
            Assert.AreEqual(1, resultado.Id, "El ID del usuario debe ser 1");
            Assert.AreEqual("admin", resultado.Username, "El nombre de usuario debe coincidir");
        }

        [TestMethod]
        public void ValidarUsuario_CredencialesIncorrectas_RetornaNull()
        {
            // Arrange
            string username = "admin";
            string password = "password_incorrecto";

            _mockRepositorio
                .Setup(x => x.ValidarUsuario(username, password))
                .Returns((UserRepository.Usuario)null);

            // Act
            var resultado = _logicaUsuarios.ValidarUsuario(username, password);

            // Assert
            Assert.IsNull(resultado, "El resultado debe ser null para credenciales incorrectas");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidarUsuario_UsernameNulo_LanzaExcepcion()
        {
            // Arrange
            string username = null;
            string password = "123456";

            _mockRepositorio
                .Setup(x => x.ValidarUsuario(username, password))
                .Throws<ArgumentNullException>();

            // Act
            _logicaUsuarios.ValidarUsuario(username, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarUsuario_UsernameVacio_LanzaExcepcion()
        {
            // Arrange
            string username = "";
            string password = "123456";

            _mockRepositorio
                .Setup(x => x.ValidarUsuario(username, password))
                .Throws<ArgumentException>();

            // Act
            _logicaUsuarios.ValidarUsuario(username, password);
        }

        // Pruebas para el método ActualizarUsuario

        [TestMethod]
        public void ActualizarUsuario_DatosValidos_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;
            string username = "juanperez_actualizado";
            string password = "nueva_contraseña";
            int rol = 2;

            // Act
            _logicaUsuarios.ActualizarUsuario(id, username, password, rol);

            // Assert
            _mockRepositorio.Verify(
                x => x.ActualizarUsuario(id, username, password, rol),
                Times.Once,
                "El método ActualizarUsuario debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActualizarUsuario_IdInvalido_LanzaExcepcion()
        {
            // Arrange
            int id = -1;
            string username = "juanperez";
            string password = "123456";
            int rol = 1;

            _mockRepositorio
                .Setup(x => x.ActualizarUsuario(id, username, password, rol))
                .Throws<ArgumentException>();

            // Act
            _logicaUsuarios.ActualizarUsuario(id, username, password, rol);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ActualizarUsuario_UsuarioNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999; // ID que no existe
            string username = "usuario_inexistente";
            string password = "123456";
            int rol = 1;

            _mockRepositorio
                .Setup(x => x.ActualizarUsuario(id, username, password, rol))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaUsuarios.ActualizarUsuario(id, username, password, rol);
        }

        // Pruebas para el método EliminarUsuario

        [TestMethod]
        public void EliminarUsuario_IdValido_InvocaMetodoDelRepositorio()
        {
            // Arrange
            int id = 1;

            // Act
            _logicaUsuarios.EliminarUsuario(id);

            // Assert
            _mockRepositorio.Verify(
                x => x.EliminarUsuario(id),
                Times.Once,
                "El método EliminarUsuario debe llamarse exactamente una vez"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarUsuario_IdInvalido_LanzaExcepcion()
        {
            // Arrange
            int id = 0;

            _mockRepositorio
                .Setup(x => x.EliminarUsuario(id))
                .Throws<ArgumentException>();

            // Act
            _logicaUsuarios.EliminarUsuario(id);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void EliminarUsuario_UsuarioNoExistente_LanzaExcepcion()
        {
            // Arrange
            int id = 999;

            _mockRepositorio
                .Setup(x => x.EliminarUsuario(id))
                .Throws<KeyNotFoundException>();

            // Act
            _logicaUsuarios.EliminarUsuario(id);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EliminarUsuario_UltimoAdministrador_LanzaExcepcion()
        {
            // Arrange
            int id = 1; // Asumiendo que es el último admin

            _mockRepositorio
                .Setup(x => x.EliminarUsuario(id))
                .Throws<InvalidOperationException>();

            // Act
            _logicaUsuarios.EliminarUsuario(id);
        }

        // Pruebas para el método BuscarUsuarios

        [TestMethod]
        public void BuscarUsuarios_NombreExistente_RetornaListaDeUsuarios()
        {
            // Arrange
            string nombre = "juan";

            var usuariosEsperados = new List<UserRepository.Usuario>
            {
                new UserRepository.Usuario { Id = 1, Username = "juanperez", Password = "hash1", Rol = 1 },
                new UserRepository.Usuario { Id = 2, Username = "juangomez", Password = "hash2", Rol = 2 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarUsuarios(nombre))
                .Returns(usuariosEsperados);

            // Act
            var resultado = _logicaUsuarios.BuscarUsuarios(nombre);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(2, resultado.Count, "Deben encontrarse 2 usuarios");
            Assert.AreEqual("juanperez", resultado[0].Username, "El primer usuario debe ser juanperez");
            Assert.AreEqual("juangomez", resultado[1].Username, "El segundo usuario debe ser juangomez");
        }

        [TestMethod]
        public void BuscarUsuarios_NombreNoExistente_RetornaListaVacia()
        {
            // Arrange
            string nombre = "usuariofalso";

            _mockRepositorio
                .Setup(x => x.BuscarUsuarios(nombre))
                .Returns(new List<UserRepository.Usuario>());

            // Act
            var resultado = _logicaUsuarios.BuscarUsuarios(nombre);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(0, resultado.Count, "La lista debe estar vacía cuando no hay coincidencias");
        }

        [TestMethod]
        public void BuscarUsuarios_NombreVacio_RetornaTodosLosUsuarios()
        {
            // Arrange
            string nombre = "";

            var todosLosUsuarios = new List<UserRepository.Usuario>
            {
                new UserRepository.Usuario { Id = 1, Username = "admin", Password = "hash1", Rol = 1 },
                new UserRepository.Usuario { Id = 2, Username = "vendedor1", Password = "hash2", Rol = 2 },
                new UserRepository.Usuario { Id = 3, Username = "vendedor2", Password = "hash3", Rol = 2 }
            };

            _mockRepositorio
                .Setup(x => x.BuscarUsuarios(nombre))
                .Returns(todosLosUsuarios);

            // Act
            var resultado = _logicaUsuarios.BuscarUsuarios(nombre);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.AreEqual(3, resultado.Count, "Con nombre vacío deben retornarse todos los usuarios");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuscarUsuarios_NombreNulo_LanzaExcepcion()
        {
            // Arrange
            string nombre = null;

            _mockRepositorio
                .Setup(x => x.BuscarUsuarios(nombre))
                .Throws<ArgumentNullException>();

            // Act
            _logicaUsuarios.BuscarUsuarios(nombre);
        }
    }
}
