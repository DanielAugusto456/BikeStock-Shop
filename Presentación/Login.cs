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
    public partial class Login : Form
    {
        Logica_de_negocio.LogicaUsuarios logica = new Logica_de_negocio.LogicaUsuarios();
        public Login()
        {
            InitializeComponent();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (txt_username.Text != string.Empty)
            {
                if (txt_password.Text != string.Empty)
                {
                    var usuario = logica.ValidarUsuario(txt_username.Text, txt_password.Text);
                    if (usuario != null)
                    {
                        MessageBox.Show("¡Bienvenido, " + txt_username.Text + "!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu menu = new Menu(usuario.Username, usuario.Rol == 1 ? "Administrador" : "Usuario");
                        menu.Owner = this;
                        this.Hide();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
