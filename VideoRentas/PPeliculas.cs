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
    public partial class PPeliculas : Form
    {

        private NPeliculas npeliculas;
        public PPeliculas()
        {
            InitializeComponent();
            npeliculas = new NPeliculas();
            CargarDatos();
        }

        void CargarDatos()
        {
            dgPeliculas.DataSource = npeliculas.obtenerPeliculasGrid();
        }

        void LimpiarDatos()
        {
            txtClienteId.Text = "";
            txtNombre.Text = "";
            txtGenero.Text = "";
            txtAutores.Text = "";
            txtExistencia.Text = "";
            txtPrecioRenta.Text = "";
            checkBoxEstado.Checked = false;
            //errorProvider1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void PPeliculas_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {

            var agregar = false;
            var peliculaId = txtClienteId.Text.ToString();
            var nombre = txtNombre.Text.ToString();
            var genero = txtGenero.Text.ToString();
            var autores = txtAutores.Text.ToString();
            var existencia = txtExistencia.Text.ToString();
            var preciorenta = txtPrecioRenta.Text.ToString();
            if (string.IsNullOrEmpty(peliculaId) || string.IsNullOrWhiteSpace(peliculaId))
            {
                agregar = true;
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider1.SetError(txtNombre, "Debe ingresar el Nombre");
                return;
            }
            if (string.IsNullOrEmpty(genero) || string.IsNullOrWhiteSpace(genero))
            {
                errorProvider1.SetError(txtGenero, "Debe ingresar el Genero");
                return;
            }
            if (string.IsNullOrEmpty(autores) || string.IsNullOrWhiteSpace(autores))
            {
                errorProvider1.SetError(txtAutores, "Debe ingresar un Autor");
                return;
            }
            if (string.IsNullOrEmpty(existencia) || string.IsNullOrWhiteSpace(existencia))
            {
                errorProvider1.SetError(txtExistencia, "Debe ingresar la cantidad de libros en existencia");
                return;
            }
            if (string.IsNullOrEmpty(preciorenta) || string.IsNullOrWhiteSpace(preciorenta))
            {
                errorProvider1.SetError(txtPrecioRenta, "Debe ingresar un precio de renta");
                return;
            }

            if (agregar)
            {
                npeliculas.AgregarPeliculas(new MPeliculas()
                {
                    Nombre = nombre,
                    Genero = genero,
                    Autores = autores,
                    Existencia = int.Parse(txtExistencia.Text.ToString()),
                    PrecioRenta = decimal.Parse(txtPrecioRenta.Text.ToString()),
                    Estado = checkBoxEstado.Checked
                });
            }
            else
            {
                npeliculas.EditarPeliculas(new MPeliculas()
                {
                    PeliculaId = int.Parse(peliculaId),
                    Nombre = nombre,
                    Genero = genero,
                    Autores = autores,
                    Existencia = int.Parse(existencia),
                    PrecioRenta = decimal.Parse(preciorenta),
                    Estado = checkBoxEstado.Checked
                });
            }

            CargarDatos();
            LimpiarDatos();

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

            var peliculaId = txtClienteId.Text.ToString();
            if (string.IsNullOrEmpty(peliculaId) || string.IsNullOrWhiteSpace(peliculaId))
            {
                return;
            }
            npeliculas.Eliminar(int.Parse(peliculaId));
            CargarDatos();
            LimpiarDatos();

        }

        private void dgPeliculas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgPeliculas.Rows.Count)
            {
                DataGridViewRow row = dgPeliculas.Rows[e.RowIndex];
                txtClienteId.Text = row.Cells["PeliculaId"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtGenero.Text = row.Cells["Genero"].Value.ToString();
                txtAutores.Text = row.Cells["Autores"].Value.ToString();
                txtExistencia.Text = row.Cells["Existencia"].Value.ToString();
                txtPrecioRenta.Text = row.Cells["PrecioRenta"].Value.ToString();
                checkBoxEstado.Checked = bool.Parse(dgPeliculas.CurrentRow.Cells["Estado"].Value.ToString());
            }
        }

        private void cbActivos_CheckedChanged_1(object sender, EventArgs e)
        {
            dgPeliculas.DataSource = npeliculas.obtenerPeliculasActivas();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }
    }
}
