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

        public NRentas()
        {
            dRentas = new DRentas();
        }


        public List<MRentas> TodaslasRentas()
        {
            return dRentas.TodaslasRentas();
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var rentas = TodaslasRentas().Select(c => new
            {
                c.ClienteId,
                c.PeliculaId,
            }).ToList();
            foreach (var item in rentas)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.ClienteId,
                    Descripcion = item.PeliculaId.ToString()
                });
            }

            return Datos;
        }
        public int AgregarRenta(MRentas rentas)
        {
            rentas.FechaRenta = DateTime.Now;
            return dRentas.Guardar(rentas);
        }
        public int EditarRenta(MRentas rentas)
        {

            return dRentas.Guardar(rentas);
        }

        public int EliminarRentas(int RentaId)
        {
            return dRentas.Eliminar(RentaId);
        }
        public List<object> ObtenerRentasGrid()
        {
            var rentas = dRentas.TodaslasRentas().Select(c => new {
                c.RentaId,
                NombreCliente = c.MClientes.Nombres +" " + c.MClientes.Apellidos,
                NombrePelicula = c.MPeliculas.Nombre,
                c.FechaRenta,
                c.FechaRetorno
            });
            return rentas.Cast<object>().ToList();
        }
    }
}
