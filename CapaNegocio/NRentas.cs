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
    public class NRentas
    {
        private DRentas dRentas;
        private DPeliculas dpeliculas;

        public NRentas()
        {
            dRentas = new DRentas();
            dpeliculas = new DPeliculas();
        }

        public List<MRentas> TodaslasRentas()
        {
            return dRentas.TodaslasRentas();
        }
        public int AgregarRenta(MRentas rentas)
        {
            var pelicula = dpeliculas.ObtenerPeliculaPorId(rentas.PeliculaId);

            if (pelicula != null && pelicula.Existencia >= rentas.Cantidad && rentas.Cantidad > 0)
            {
                rentas.FechaRenta = DateTime.Now;
                return dRentas.Guardar(rentas);
            }
            else if (pelicula == null)
            {
                throw new CapaNegocio.NoExistenciaException("La película seleccionada no existe en la base de datos.");
            }
            else if (pelicula.Existencia < rentas.Cantidad)
            {
                throw new CapaNegocio.NoExistenciaException("La cantidad ingresada supera las existencias disponibles de la película.");
            }
            else if (rentas.Cantidad <= 0)
            {
                throw new CapaNegocio.NoExistenciaException("La cantidad debe ser mayor que cero.");
            }
            throw new CapaNegocio.NoExistenciaException("No se puede rentar la película seleccionada debido a un problema desconocido.");
        }
        public int EditarRenta(MRentas rentas)
        {

            var pelicula = dpeliculas.ObtenerPeliculaPorId(rentas.PeliculaId);

            if (pelicula != null && pelicula.Existencia >= rentas.Cantidad && rentas.Cantidad > 0)
            {
                rentas.FechaRenta = DateTime.Now;
                return dRentas.Guardar(rentas);
            }
            else if (pelicula == null)
            {
                throw new CapaNegocio.NoExistenciaException("La película seleccionada no existe en la base de datos.");
            }
            else if (pelicula.Existencia < rentas.Cantidad)
            {
                throw new CapaNegocio.NoExistenciaException("La cantidad ingresada supera las existencias disponibles de la película.");
            }
            else if (rentas.Cantidad <= 0)
            {
                throw new CapaNegocio.NoExistenciaException("La cantidad debe ser mayor que cero.");
            }
            throw new CapaNegocio.NoExistenciaException("No se puede rentar la película seleccionada debido a un problema desconocido.");
        }

        public int EliminarRentas(int RentaId)
        {
            return dRentas.Eliminar(RentaId);
        }
        public List<object> ObtenerRentasGrid()
        {
            var rentas = dRentas.TodaslasRentas().Select(c => new {
                c.RentaId,
                NombreCliente = c.MClientes.Nombres + " " + c.MClientes.Apellidos,
                NombrePelicula = c.MPeliculas.Nombre,
                c.FechaRenta,
                c.FechaRetorno,
                c.Cantidad,
                c.PrecioRenta
            });
            return rentas.Cast<object>().ToList();
        }
    }
}
