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
    public partial class VentStock : Form
    {
        public int id;
        public int disponible;
        public int reparacion;
        public bool data = true;
        Logica_de_negocio.LogicaBicicleta logica = new Logica_de_negocio.LogicaBicicleta();

        public VentStock(int _id, int _disponible, int _reparacion)
        {
            InitializeComponent();
            id = _id;
            disponible = _disponible;
            reparacion = _reparacion;   
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void VentStock_Load(object sender, EventArgs e)
        {
            txt_disponible.Text = disponible.ToString();
            txt_reparacion.Text = reparacion.ToString();
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            if ((txt_disponible.Text != "") && (txt_reparacion.Text != ""))
            {
                disponible = Convert.ToInt32(txt_disponible.Text);
                reparacion = Convert.ToInt32(txt_reparacion.Text);
                logica.ActualizarStock(id, disponible, reparacion);
                MessageBox.Show("Stock actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, complete ambos campos para actualizar el stock.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                data = false;
            }
        }
    }
}
