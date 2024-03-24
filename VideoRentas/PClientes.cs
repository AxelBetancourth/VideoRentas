using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentas
{
    public partial class PClientes : Form
    {
        private NClientes nClientes;

        public PClientes()
        {
            InitializeComponent();
            nClientes = new NClientes();

        }

        private void PClientes_Load(object sender, EventArgs e)
        {

        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
