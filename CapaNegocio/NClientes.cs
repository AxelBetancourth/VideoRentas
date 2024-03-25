using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
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
    }
}
