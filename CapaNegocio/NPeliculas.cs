using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
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
            return dpeliculas.TodasLasPeliculas().Where(c => c.Estado == false).ToList();
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
    }
}



