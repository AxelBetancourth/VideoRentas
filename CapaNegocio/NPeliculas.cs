using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
using CapaNegocio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPeliculas
    {
        private DPeliculas dpeliculas;
        public NPeliculas()
        {
            dpeliculas = new DPeliculas();
        }

        public List<MPeliculas> obtenerPeliculas()
        {
            return dpeliculas.TodasLasPeliculas();
        }

        public List<MPeliculas> obtenerPeliculasActivas()
        {
            return dpeliculas.TodasLasPeliculas().Where(c => c.Estado == true).ToList();
        }

        public List<MPeliculas> obtenerPeliculasGrid()
        {
            var peliculas = dpeliculas.TodasLasPeliculas().Select(c => new { c.PeliculaId, c.Nombre, c.Genero, c.Autores, c.Existencia, c.PrecioRenta, c.Estado });
            return dpeliculas.TodasLasPeliculas().ToList();
        }

        public int AgregarPeliculas(MPeliculas peliculas)
        {
            return dpeliculas.Guardar(peliculas);
        }

        public int EditarPeliculas(MPeliculas peliculas)
        {
            return dpeliculas.Guardar(peliculas);
        }

        public int Eliminar(int peliculaId)
        {
            return dpeliculas.EliminarPeliculas(peliculaId);
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var clientes = obtenerPeliculas().Select(c => new
            {
                c.Nombre,
                c.PeliculaId,
            }).ToList();
            foreach (var item in clientes)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.PeliculaId,
                    Descripcion = item.Nombre
                });
            }

            return Datos;
        }

    }
}



