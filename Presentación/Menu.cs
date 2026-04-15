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
    }
}
