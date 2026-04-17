using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class Menu : Form
    {
        private string username;
        private string rol;
        bool data = false;
        Logica_de_negocio.LogicaBicicleta Logica_bicicleta = new Logica_de_negocio.LogicaBicicleta();
        Logica_de_negocio.LogicaAccesorios Logica_accesorios = new Logica_de_negocio.LogicaAccesorios();
        Logica_de_negocio.LogicaUsuarios LogicaUsuarios = new Logica_de_negocio.LogicaUsuarios();

        public Menu(string _username, string _rol)
        {
            InitializeComponent();
            username = _username;
            rol = _rol;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lbl_username.Text = username;
            lbl_rol.Text = rol;
            if (rol == "Administrador")
            {
                btn_usuarios.Visible = true;
            }
        }

        private void btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        // panel de bicicletas

        private void limpiar_campos_bicicleta()
        {
            lbl_codigo_bicicleta.Text = "";
            txt_marca_bicicleta.Clear();
            txt_modelo_bicicleta.Clear();
            txt_color_bicicleta.Clear();
            txt_precio_bicicleta.Clear();
            lbl_disponible.Text = "";
            lbl_Reparacion.Text = "";
            data = false;
        }

        private bool verificar_campos_bicicleta()
        {
            if (string.IsNullOrWhiteSpace(txt_marca_bicicleta.Text) ||
                string.IsNullOrWhiteSpace(txt_modelo_bicicleta.Text) ||
                string.IsNullOrWhiteSpace(txt_color_bicicleta.Text) ||
                string.IsNullOrWhiteSpace(txt_precio_bicicleta.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos de la bicicleta.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_buscar_bicicletas_Click(object sender, EventArgs e)
        {
            VentBicicletas ventBicicletas = new VentBicicletas();
            ventBicicletas.Owner = this;
            ventBicicletas.ShowDialog();

            if (ventBicicletas.data)
            {
                // asignar los valores seleccionados a las variables correspondientes
                data = true;
                int selectedCodigo = ventBicicletas.codigo;
                lbl_codigo_bicicleta.Text = selectedCodigo.ToString();
                txt_marca_bicicleta.Text = ventBicicletas.marca;
                txt_modelo_bicicleta.Text = ventBicicletas.modelo;
                txt_color_bicicleta.Text = ventBicicletas.color;
                txt_precio_bicicleta.Text = ventBicicletas.precio;
                int disponible = ventBicicletas.disponible;
                lbl_disponible.Text = disponible.ToString();
                int reparacion = ventBicicletas.reparacion;
                lbl_Reparacion.Text = reparacion.ToString();
            }
        }

        private void btn_crear_bicicleta_Click(object sender, EventArgs e)
        {
            if (verificar_campos_bicicleta())
            {
                if (data != true)
                {
                    Logica_bicicleta.IngresarBicicleta(txt_marca_bicicleta.Text, txt_modelo_bicicleta.Text, txt_color_bicicleta.Text, decimal.Parse(txt_precio_bicicleta.Text), 0, 0);
                    MessageBox.Show("Bicicleta creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_bicicleta();
                }
                else
                {
                    MessageBox.Show("La bicicleta ya existe. Por favor, limpie los campos para crear una nueva bicicleta.", "Bicicleta existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_limpiar_bicicleta_Click(object sender, EventArgs e)
        {
            limpiar_campos_bicicleta();
        }

        private void btn_stock_bicicleta_Click(object sender, EventArgs e)
        {
            if (data)
            {
                VentStock ventStock = new VentStock(Convert.ToInt32(lbl_codigo_bicicleta.Text), Convert.ToInt32(lbl_disponible.Text), Convert.ToInt32(lbl_Reparacion.Text));
                ventStock.Owner = this;
                ventStock.ShowDialog();

                if (ventStock.data)
                {
                    int disponible = ventStock.disponible;
                    lbl_disponible.Text = disponible.ToString();
                    int reparacion = ventStock.reparacion;
                    lbl_Reparacion.Text = reparacion.ToString();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una bicicleta para actualizar su stock.", "Bicicleta no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_actualizar_bicicleta_Click(object sender, EventArgs e)
        {
            if (data)
            {
                if (verificar_campos_bicicleta())
                {
                    Logica_bicicleta.ActualizarBicicleta(Convert.ToInt32(lbl_codigo_bicicleta.Text), txt_marca_bicicleta.Text, txt_modelo_bicicleta.Text, txt_color_bicicleta.Text, decimal.Parse(txt_precio_bicicleta.Text), Convert.ToInt32(lbl_disponible.Text), Convert.ToInt32(lbl_Reparacion.Text));
                    MessageBox.Show("Bicicleta actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_bicicleta();
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos de la bicicleta para actualizar su información.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una bicicleta para actualizar su información.", "Bicicleta no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_borrar_bicleta_Click(object sender, EventArgs e)
        {
            if (data)
            {
                Logica_bicicleta.EliminarBicicleta(Convert.ToInt32(lbl_codigo_bicicleta.Text));
                MessageBox.Show("Bicicleta eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar_campos_bicicleta();
            }
            else
            {
                MessageBox.Show("Seleccione una bicicleta para eliminarla.", "Bicicleta no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_bicicletas_Click(object sender, EventArgs e)
        {
            limpiar_campos_bicicleta();
            data = false;
            panel_accesorios.Visible = false;
            panel_usuarios.Visible = false;
            panel_bicicletas.Visible = true;
        }

        // panel de accesorios

        private void btn_accesorios_Click(object sender, EventArgs e)
        {
            limpiar_campos_accesorio();
            data = false;
            panel_bicicletas.Visible = false;
            panel_usuarios.Visible = false;
            panel_accesorios.Visible = true;
        }

        private void limpiar_campos_accesorio()
        {
            lbl_codigo_accesorio.Text = "";
            txt_nombre_accesorio.Clear();
            txt_tipo_accesorio.Clear();
            txt_marca_accesorio.Clear();
            txt_precio_accesorio.Clear();
            txt_stock_accesorio.Clear();
            data = false;
        }

        private bool verificar_campos_accesorio()
        {
            if (string.IsNullOrWhiteSpace(txt_nombre_accesorio.Text) ||
                string.IsNullOrWhiteSpace(txt_tipo_accesorio.Text) ||
                string.IsNullOrWhiteSpace(txt_marca_accesorio.Text) ||
                string.IsNullOrWhiteSpace(txt_precio_accesorio.Text) ||
                string.IsNullOrWhiteSpace(txt_stock_accesorio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del accesorio.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_buscar_accesorio_Click(object sender, EventArgs e)
        {
            VentAccesorio ventAccesorio = new VentAccesorio();
            ventAccesorio.Owner = this;
            ventAccesorio.ShowDialog();

            if (ventAccesorio.data)
            {
                int codigo = ventAccesorio._id;
                lbl_codigo_accesorio.Text = codigo.ToString();
                txt_nombre_accesorio.Text = ventAccesorio._nombre;
                txt_tipo_accesorio.Text = ventAccesorio._tipo;
                txt_marca_accesorio.Text = ventAccesorio._marca;
                int precio = ventAccesorio._precio;
                txt_precio_accesorio.Text = precio.ToString();
                int stock = ventAccesorio._stock;
                txt_stock_accesorio.Text = stock.ToString();
                data = true;
            }
        }

        private void btn_crear_accesorio_Click(object sender, EventArgs e)
        {
            if (!data)
            {
                if (verificar_campos_accesorio())
                {
                    Logica_accesorios.InsertarAccesorio(txt_nombre_accesorio.Text, txt_tipo_accesorio.Text, txt_marca_accesorio.Text,
                        decimal.Parse(txt_precio_accesorio.Text), Convert.ToInt32(txt_stock_accesorio.Text));
                    MessageBox.Show("Accesorio creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_accesorio();
                }
            }
            else
            {
                MessageBox.Show("El accesorio ya existe. Por favor, limpie los campos para crear un nuevo accesorio.", "Accesorio existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_limpiar_accesorio_Click(object sender, EventArgs e)
        {
            limpiar_campos_accesorio();
        }

        private void btn_actualizar_accesorio_Click(object sender, EventArgs e)
        {
            if (data)
            {
                if (verificar_campos_accesorio())
                {
                    Logica_accesorios.ActualizarAccesorio(int.Parse(lbl_codigo_accesorio.Text), txt_nombre_accesorio.Text, txt_tipo_accesorio.Text, txt_marca_accesorio.Text,
                        decimal.Parse(txt_precio_accesorio.Text), Convert.ToInt32(txt_stock_accesorio.Text));
                    MessageBox.Show("Accesorio actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_accesorio();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un accesorio para actualizar su información.", "Accesorio no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_borrar_accesorio_Click(object sender, EventArgs e)
        {
            if (data)
            {
                Logica_accesorios.EliminarAccesorio(int.Parse(lbl_codigo_accesorio.Text));
                MessageBox.Show("Accesorio eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar_campos_accesorio();
            }
            else
            {
                MessageBox.Show("Seleccione un accesorio para eliminarlo.", "Accesorio no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // panel de usuarios
        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            data = false;
            limpiar_campos_usuario();

            panel_bicicletas.Visible = false;
            panel_accesorios.Visible = false;
            panel_usuarios.Visible = true;
        }

        private void limpiar_campos_usuario()
        {
            lbl_id_usuario.Text = "";
            txt_username.Clear();
            txt_password.Clear();
            txt_rol.Clear();
            data = false;
        }   

        private bool verificar_campos_usuario()
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) ||
                string.IsNullOrWhiteSpace(txt_password.Text) ||
                string.IsNullOrWhiteSpace(txt_rol.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del usuario.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_buscar_usuario_Click(object sender, EventArgs e)
        {
            VentUsuarios ventUsuarios = new VentUsuarios();
            ventUsuarios.Owner = this;
            ventUsuarios.ShowDialog();

            if (ventUsuarios.data)
            {
                int id = ventUsuarios._id;
                lbl_id_usuario.Text = id.ToString();
                txt_username.Text = ventUsuarios._nombre;
                txt_password.Text = ventUsuarios._password;
                txt_rol.Text = ventUsuarios._rol;
                data = true;
            }
        }

        private void btn_cambiar_rol_Click(object sender, EventArgs e)
        {
            if (txt_rol.Text == "Administrador")
            {
                txt_rol.Text = "Usuario";
            }
            else
            {
                txt_rol.Text = "Administrador";
            }
        }

        private void btn_crear_usuario_Click(object sender, EventArgs e)
        {
            if (!data)
            {
                if (verificar_campos_usuario())
                {
                    LogicaUsuarios.IngresarUsuario(txt_username.Text, txt_password.Text, txt_rol.Text == "Administrador" ? 1 : 0);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_usuario();
                }
            }
            else
            {
                MessageBox.Show("El usuario ya existe. Por favor, limpie los campos para crear un nuevo usuario.", "Usuario existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_actualizar_usuario_Click(object sender, EventArgs e)
        {
            if (data)
            {
                if (verificar_campos_usuario())
                {
                    LogicaUsuarios.ActualizarUsuario(int.Parse(lbl_id_usuario.Text), txt_username.Text, txt_password.Text, txt_rol.Text == "Administrador" ? 1 : 0);
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_campos_usuario();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para actualizar su información.", "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }
        }

        private void btn_limpiar_usuario_Click(object sender, EventArgs e)
        {
            limpiar_campos_usuario();
        }

        private void btn_borrar_usuario_Click(object sender, EventArgs e)
        {
            if (data)
            {
                LogicaUsuarios.EliminarUsuario(int.Parse(lbl_id_usuario.Text));
                MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar_campos_usuario();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminarlo.", "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
