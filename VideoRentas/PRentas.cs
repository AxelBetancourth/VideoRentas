using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentas
{
    public partial class PRentas : Form
    {
        private NRentas nRentas;
        private NClientes nClientes;
        private NPeliculas nPeliculas;
        public PRentas()
        {
            InitializeComponent();
            nRentas = new NRentas();
            nClientes = new NClientes();
            nPeliculas = new NPeliculas();
            CargarDatos();
            CargarCombos();
        }

        private void PRentas_Load(object sender, EventArgs e)
        {

        }

        void CargarDatos()
        {
            dgRenta.DataSource = nRentas.ObtenerRentasGrid();
        }

        void LimpiarDatos()
        {
            txtRentaId.Text = "";
            cboxCliente.SelectedValue = "";
            cboxPelicula.SelectedValue = "";
            dtFechaRetorno.Value = DateTime.Today;
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            errorProvider1.Clear();
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(cboxCliente.SelectedValue.ToString()) || string.IsNullOrWhiteSpace(cboxCliente.SelectedValue.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(cboxCliente, "Debe seleccionar un Cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(cboxPelicula.SelectedValue.ToString()) || string.IsNullOrWhiteSpace(cboxPelicula.SelectedValue.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(cboxPelicula, "Debe deleccionar una Pelicula");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(dtFechaRetorno.Value.ToString()) || string.IsNullOrWhiteSpace(dtFechaRetorno.Value.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(dtFechaRetorno, "Debe ingresar una Fecha");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text.ToString()) || string.IsNullOrWhiteSpace(txtCantidad.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtCantidad, "Debe ingresar una Cantidad");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text.ToString()) || string.IsNullOrWhiteSpace(txtPrecio.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtPrecio, "Debe ingresar un Precio");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void CargarCombos()
        {
            cboxCliente.DataSource = nClientes.CargaCombo();
            cboxCliente.ValueMember = "Valor";
            cboxCliente.DisplayMember = "Descripcion";

            cboxPelicula.DataSource = nPeliculas.CargaCombo();
            cboxPelicula.ValueMember = "Valor";
            cboxPelicula.DisplayMember = "Descripcion";
        }
        private void dgRenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
              private void dgRenta_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgRenta.Rows.Count)
            {

                txtRentaId.Text = dgRenta.CurrentRow.Cells["RentaId"].Value.ToString();
                var cliente = dgRenta.CurrentRow.Cells["NombreCliente"].Value.ToString();
                cboxCliente.SelectedIndex = cboxCliente.FindStringExact(cliente);
                var Pelicula = dgRenta.CurrentRow.Cells["NombrePelicula"].Value.ToString();
                cboxPelicula.SelectedIndex = cboxPelicula.FindStringExact(Pelicula);
                txtCantidad.Text = dgRenta.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtPrecio.Text = dgRenta.CurrentRow.Cells["PrecioRenta"].Value.ToString();
            }
        }
        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var agregar = false;
                var rentaId = txtRentaId.Text.ToString();
                var cliente = int.Parse(cboxCliente.SelectedValue.ToString());
                var pelicula = int.Parse(cboxPelicula.SelectedValue.ToString());
                var fecha = dtFechaRetorno.Value;
                var cantidad = txtCantidad.Text.ToString();
                var precio = txtPrecio.Text.ToString();

                if (string.IsNullOrEmpty(rentaId) || string.IsNullOrWhiteSpace(rentaId))
                {
                    agregar = true;
                }
                if (cboxCliente.SelectedItem == null || string.IsNullOrWhiteSpace(cboxCliente.SelectedValue.ToString()))
                {
                    errorProvider1.SetError(cboxCliente, "Debe seleccionar un Cliente");
                    return;
                }
                if (cboxPelicula.SelectedItem == null || string.IsNullOrWhiteSpace(cboxPelicula.SelectedValue.ToString()))
                {
                    errorProvider1.SetError(cboxPelicula, "Debe seleccionar una Película");
                    return;
                }
                if (string.IsNullOrEmpty(cantidad) || string.IsNullOrWhiteSpace(cantidad))
                {
                    errorProvider1.SetError(txtCantidad, "Debe ingresar una Cantidad");
                    return;
                }
                if (string.IsNullOrEmpty(precio) || string.IsNullOrWhiteSpace(precio))
                {
                    errorProvider1.SetError(txtPrecio, "Debe ingresar el Precio");
                    return;
                }

                if (agregar)
                {
                    nRentas.AgregarRenta(new MRentas()
                    {
                        ClienteId = cliente,
                        PeliculaId = pelicula,
                        FechaRetorno = fecha,
                        Cantidad = int.Parse(txtCantidad.Text.ToString()),
                        PrecioRenta = decimal.Parse(txtPrecio.Text.ToString()),
                    });
                }
                else
                {
                    nRentas.EditarRenta(new MRentas()
                    {
                        RentaId = int.Parse(rentaId),
                        ClienteId = cliente,
                        PeliculaId = pelicula,
                        FechaRetorno = fecha,
                        Cantidad = int.Parse(txtCantidad.Text.ToString()),
                        PrecioRenta = decimal.Parse(txtPrecio.Text.ToString()),
                    });
                }

                CargarDatos();
                LimpiarDatos();
            }
            catch (CapaNegocio.NoExistenciaException)
            {
                MessageBox.Show("No se puede rentar la película seleccionada porque no hay existencias disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var rentaId = txtRentaId.Text.ToString();
            if (string.IsNullOrEmpty(rentaId) || string.IsNullOrWhiteSpace(rentaId))
            {
                return;
            }
            nRentas.EliminarRentas(int.Parse(rentaId));
            CargarDatos();
            LimpiarDatos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
{
    e.Handled = true;
}
        }
    }
}
