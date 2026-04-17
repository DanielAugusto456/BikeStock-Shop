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
    public partial class VentAccesorio : Form
    {
        public int _id;
        public string _nombre;
        public string _tipo;
        public string _marca;
        public int _precio;
        public int _stock;
        public bool data = false;

        Logica_de_negocio.LogicaAccesorios logica = new Logica_de_negocio.LogicaAccesorios();
        public VentAccesorio()
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
            dataGridView_accesorios.Rows.Clear();
            dataGridView_accesorios.Refresh();

            var accesorios = logica.BuscarAccesorios(txt_nombre.Text, txt_tipo.Text, txt_marca.Text);
            foreach (var accesorio in accesorios)
            {
                dataGridView_accesorios.Rows.Add(accesorio.Id, accesorio.Nombre, accesorio.tipo, accesorio.Marca,
                    accesorio.Precio, accesorio.Stock);
            }
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_accesorios.CurrentCell != null)
            {
                _id = Convert.ToInt32(dataGridView_accesorios.CurrentRow.Cells[0].Value);
                _nombre = dataGridView_accesorios.CurrentRow.Cells[1].Value.ToString();
                _tipo = dataGridView_accesorios.CurrentRow.Cells[2].Value.ToString();
                _marca = dataGridView_accesorios.CurrentRow.Cells[3].Value.ToString();
                _precio = Convert.ToInt32(dataGridView_accesorios.CurrentRow.Cells[4].Value);
                _stock = Convert.ToInt32(dataGridView_accesorios.CurrentRow.Cells[5].Value);
                data = true;
                
                this.Owner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un accesorio de la tabla");
            }
        }
    }
}
