using CapaDatos.BaseDatos.Modelos;
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
            CargarDatos();
        }

        private void PClientes_Load(object sender, EventArgs e)
        {

        }

        void CargarDatos()
        {
            dgClientes.DataSource = nClientes.obtenerClientes();
        }

        void LimpiarDatos()
        {
            txtClienteId.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cbEstado.Checked = false;
            errorProvider1.Clear();
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgClientes.DataSource = nClientes.obtenerClientesActivos();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var agregar = false;
            var clienteId = txtClienteId.Text.ToString();
            var nombres = txtNombres.Text.ToString();
            var apellidos = txtApellidos.Text.ToString();

            if (string.IsNullOrEmpty(clienteId) || string.IsNullOrWhiteSpace(clienteId))
            {
                agregar = true;
            }
            if (string.IsNullOrEmpty(nombres) || string.IsNullOrWhiteSpace(nombres))
            {
                errorProvider1.SetError(txtNombres, "Debe ingresar los nombres");
                return;
            }
            if (string.IsNullOrEmpty(apellidos) || string.IsNullOrWhiteSpace(apellidos))
            {
                errorProvider1.SetError(txtApellidos, "Debe ingresar los apellidos");
                return;
            }

            if (agregar)
            {
                nClientes.AgregarClientes(new MClientes()
                {
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Estado = cbEstado.Checked
                });
            }
            else
            {
                nClientes.EditarClientes(new MClientes()
                {
                    ClienteId = int.Parse(clienteId),
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Estado = cbEstado.Checked
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteId.Text.ToString()) ||
                !string.IsNullOrWhiteSpace(txtClienteId.Text.ToString()))
            {
                if (int.Parse(txtClienteId.Text.ToString()) != 0)
                {
                    var clienteId = int.Parse(txtClienteId.Text.ToString());
                    nClientes.EliminarClientes(clienteId);
                    CargarDatos();
                    LimpiarDatos();
                }
            }
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgClientes.Rows.Count)
            {
                DataGridViewRow row = dgClientes.Rows[e.RowIndex];
                txtClienteId.Text = row.Cells["ClienteId"].Value.ToString();
                txtNombres.Text = row.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                cbEstado.Checked = bool.Parse(dgClientes.CurrentRow.Cells["Estado"].Value.ToString());
            }
        }
    }
}
