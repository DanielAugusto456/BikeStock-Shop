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
        Logica_de_negocio.LogicaBicicleta Logica = new Logica_de_negocio.LogicaBicicleta();

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
                    Logica.IngresarBicicleta(txt_marca_bicicleta.Text, txt_modelo_bicicleta.Text, txt_color_bicicleta.Text, decimal.Parse(txt_precio_bicicleta.Text), 0, 0);
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
                    Logica.ActualizarBicicleta(Convert.ToInt32(lbl_codigo_bicicleta.Text), txt_marca_bicicleta.Text, txt_modelo_bicicleta.Text, txt_color_bicicleta.Text, decimal.Parse(txt_precio_bicicleta.Text), Convert.ToInt32(lbl_disponible.Text), Convert.ToInt32(lbl_Reparacion.Text));
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
                Logica.EliminarBicicleta(Convert.ToInt32(lbl_codigo_bicicleta.Text));
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
            panel_bicicletas.Visible = true;
        }
    }
}
