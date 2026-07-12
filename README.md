# BikeStock & Shop

Sistema de escritorio en **C# (.NET, WinForms)** para la gestión de inventario de una tienda de bicicletas. Permite administrar bicicletas, accesorios y usuarios del sistema, con control de acceso por roles y una arquitectura en capas (presentación, lógica de negocio y datos) conectada a **SQL Server**.

## Características

- **Login con autenticación y roles**: acceso mediante usuario y contraseña; el rol (`Administrador` / `Usuario`) determina qué módulos están disponibles.
- **Gestión de bicicletas**: crear, buscar, actualizar y eliminar bicicletas (marca, modelo, color, precio), además de controlar por separado las unidades **disponibles** y en **reparación**.
- **Gestión de accesorios**: crear, buscar, actualizar y eliminar accesorios (nombre, tipo, marca, precio, stock).
- **Gestión de usuarios** *(solo Administrador)*: crear, buscar, actualizar y eliminar usuarios, y alternar su rol entre Administrador y Usuario.
- Ventanas de búsqueda independientes (con `DataGridView`) para seleccionar bicicletas, accesorios o usuarios existentes y cargarlos en el panel principal para editarlos.

## Arquitectura

El proyecto está organizado en tres capas, cada una como un proyecto independiente dentro de la misma solución (`BikeStock & Shop.sln`):

```
BikeStock-Shop/
├── Presentación/          # Interfaz de usuario (WinForms)
│   ├── Login.cs               # Pantalla de inicio de sesión
│   ├── Menu.cs                 # Ventana principal con los paneles de Bicicletas, Accesorios y Usuarios
│   ├── VentBicicletas.cs      # Diálogo de búsqueda/selección de bicicletas
│   ├── VentAccesorio.cs       # Diálogo de búsqueda/selección de accesorios
│   ├── VentUsuarios.cs        # Diálogo de búsqueda/selección de usuarios
│   └── VentStock.cs           # Diálogo para actualizar disponibilidad/reparación de una bicicleta
│
├── Logica de negocio/     # Capa intermedia entre la UI y el acceso a datos
│   ├── LogicaBicicleta.cs
│   ├── LogicaAccesorios.cs
│   └── LogicaUsuarios.cs
│
└── Datos/                  # Acceso a datos (SQL Server vía ADO.NET)
    ├── BicecletasRepository.cs
    ├── AccesoriosRepository.cs
    ├── UserRepository.cs
    └── cnn.cs               # Cadena de conexión a la base de datos
```

> El repositorio incluye además un proyecto `BikeSock & Shop/` con un formulario en blanco por defecto; no forma parte de la solución (`.sln`) ni se ejecuta — quedó del proyecto inicial de Visual Studio y puede ignorarse o eliminarse.

Cada repositorio de datos (`Datos/`) se comunica con la base de datos ejecutando **stored procedures** de SQL Server (por ejemplo `sp_InsertarBicicleta`, `sp_BuscarBicicletas`, `sp_ActualizarStockBicicleta`, `sp_ValidarUsuario`, etc.), en lugar de construir sentencias SQL directamente en el código.

## Requisitos

- Visual Studio 2022 (o compatible) con soporte para desarrollo de escritorio .NET
- .NET Framework 4.7.2
- SQL Server (local o remoto) con las tablas y stored procedures correspondientes a bicicletas, accesorios y usuarios

## Configuración

1. Clona el repositorio:
   ```bash
   git clone https://github.com/DanielAugusto456/BikeStock-Shop.git
   ```
2. Crea la base de datos `BikeStock % Shop` en tu instancia de SQL Server, junto con las tablas y stored procedures que usan los repositorios (`sp_InsertarBicicleta`, `sp_BuscarBicicletas`, `sp_ActualiarStockBicicleta`, `sp_ActualizarBicicleta`, `sp_EliminarBicicleta`, `sp_InsertarAccesorio`, `sp_ActualizarAccesorio`, `sp_BuscarAccesorios`, `sp_EliminarAccesorio`, `sp_InsertarUsuario`, `sp_ValidarUsuario`, `sp_ActualizarUsuario`, `sp_EliminarUsuario`, `sp_BuscarUsuario`).
3. Ajusta la cadena de conexión en `Datos/cnn.cs` según tu entorno (por defecto usa autenticación integrada de Windows contra una instancia local):
   ```csharp
   public static string db = @"Data Source=TU_SERVIDOR;Initial Catalog=BikeStock % Shop;Integrated Security=True";
   ```
4. Abre `BikeStock & Shop.sln` en Visual Studio y compila la solución (proyectos `Presentación`, `Logica de negocio` y `Datos`).
5. Ejecuta el proyecto `Presentación`.

> **Nota:** actualmente el punto de entrada (`Presentación/Program.cs`) abre directamente la ventana `Menu` con un usuario administrador de prueba, sin pasar por `Login`. Para usar el flujo de autenticación real, cambia el `Main()` para que inicie con `new Login()` en lugar de `new Menu(...)`.

## Uso

- **Login**: ingresa usuario y contraseña. Si el rol es Administrador, el menú principal muestra también el panel de Usuarios.
- **Bicicletas**: completa marca, modelo, color y precio para crear una bicicleta; usa "Buscar" para localizar una existente y cargarla en el formulario, y desde ahí actualizarla, eliminarla o gestionar su stock (unidades disponibles y en reparación).
- **Accesorios**: mismo flujo de crear/buscar/actualizar/eliminar, con nombre, tipo, marca, precio y stock.
- **Usuarios** *(solo Administrador)*: crear/buscar/actualizar/eliminar usuarios y cambiar su rol entre Administrador y Usuario.

## Autor

**Daniel Augusto Martinez Zapata**
📧 MartinezZapata809@gmail.com
🌐 [mi portafolio](https://danielaugustoportafolio.surge.sh)
