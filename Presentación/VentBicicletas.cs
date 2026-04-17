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
    public partial class VentBicicletas : Form
    {
        public int codigo;
        public string marca;
        public string modelo;
        public string color;
        public string precio;
        public int disponible;
        public int reparacion;
        public bool data = false;
        Logica_de_negocio.LogicaBicicleta Logica = new Logica_de_negocio.LogicaBicicleta();

        public VentBicicletas()
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
            dataGridView_bicicletas.Rows.Clear();
            dataGridView_bicicletas.Refresh();

            var bicicletas = Logica.ObtenerBicicletas(txt_marca.Text, txt_modelo.Text, txt_color.Text);
            foreach (var bicicleta in bicicletas)
            {
                dataGridView_bicicletas.Rows.Add(bicicleta.Id, bicicleta.Marca, bicicleta.Modelo, bicicleta.Color, bicicleta.Precio,
                    bicicleta.Disponible, bicicleta.Reparacion);
            }
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_bicicletas.CurrentCell != null)
            {
                codigo = Convert.ToInt32(dataGridView_bicicletas.CurrentRow.Cells[0].Value);
                marca = dataGridView_bicicletas.CurrentRow.Cells[1].Value.ToString();
                modelo = dataGridView_bicicletas.CurrentRow.Cells[2].Value.ToString();
                color = dataGridView_bicicletas.CurrentRow.Cells[3].Value.ToString();
                precio = dataGridView_bicicletas.CurrentRow.Cells[4].Value.ToString();
                disponible = Convert.ToInt32(dataGridView_bicicletas.CurrentRow.Cells[5].Value);
                reparacion = Convert.ToInt32(dataGridView_bicicletas.CurrentRow.Cells[6].Value);
                data = true;
                this.Owner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una bicicleta de la tabla para seleccionar.");
            }
        }
    }
}
