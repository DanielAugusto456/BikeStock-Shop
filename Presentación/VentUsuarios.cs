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
    public partial class VentUsuarios : Form
    {
        public int _id;
        public string _nombre;
        public string _password;
        public string _rol;
        public bool data;
        Logica_de_negocio.LogicaUsuarios logica = new Logica_de_negocio.LogicaUsuarios();

        public VentUsuarios()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dataGridView_usuarios.Rows.Clear();
            dataGridView_usuarios.Refresh();

            var usuarios = logica.BuscarUsuarios(txt_nombre.Text);
            foreach (var usuario in usuarios)
            {
                dataGridView_usuarios.Rows.Add(usuario.Id, usuario.Username, usuario.Password, usuario.Rol == 1 ? "Administrador" : "Usuario");
            }
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_usuarios.CurrentCell != null)
            {
                _id = int.Parse(dataGridView_usuarios.CurrentRow.Cells[0].Value.ToString());
                _nombre = dataGridView_usuarios.CurrentRow.Cells[1].Value.ToString();
                _password = dataGridView_usuarios.CurrentRow.Cells[2].Value.ToString();
                _rol = dataGridView_usuarios.CurrentRow.Cells[3].Value.ToString();
                data = true;

                this.Owner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
        }
    }
}
