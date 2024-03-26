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
    public class NClientes
    {
        private DClientes dClientes;
        public NClientes()
        {
            dClientes = new DClientes();
        }

        public List<MClientes> obtenerClientes()
        {
            return dClientes.TodosLosClientes();
        }

        public List<MClientes> obtenerClientesActivos()
        {
            return dClientes.TodosLosClientes().Where(c => c.Estado == true).ToList();
        }

        public int AgregarClientes(MClientes cliente)
        {
            cliente.FechaIngreso = DateTime.Now;
            return dClientes.Guardar(cliente);
        }

        public int EditarClientes(MClientes cliente)
        {
            return dClientes.Guardar(cliente);
        }

        public int EliminarClientes(int clienteId)
        {
            return dClientes.Eliminar(clienteId);
        }

        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var clientes = obtenerClientes().Select(c => new
            {
                c.Nombres,
                c.Apellidos,
                c.ClienteId,
            }).ToList();
            foreach (var item in clientes)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.ClienteId,
                    Descripcion = item.Nombres + " " + item.Apellidos
                });
            }

            return Datos;
        }

    }
}
