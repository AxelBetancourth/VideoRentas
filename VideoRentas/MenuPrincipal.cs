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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void peliculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPeliculas peliculas = new PPeliculas();
            peliculas.MdiParent = this;
            peliculas.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PClientes clientes = new PClientes();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void rentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRentas rentas = new PRentas();
            rentas.MdiParent = this;
            rentas.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        }
    }
}
