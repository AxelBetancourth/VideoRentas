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

        public List<MClientes> obtenerClientesInactivos()
        {
            return dClientes.TodosLosClientes().Where(c => c.Estado == true).ToList();
        }

        public List<MClientes> obtenerClientesGrid()
        {
            var clientes = dClientes.TodosLosClientes().Select(c => new { c.ClienteId, c.Nombres, c.Apellidos});
            return dClientes.TodosLosClientes().ToList();
        }

        public int Agregar(MClientes cliente)
        {
            cliente.FechaIngreso = DateTime.Now;
            return dClientes.GuardarClientes(cliente);
        }

        public int Editar(MClientes cliente)
        {
            return dClientes.GuardarClientes(cliente);
        }

        public int Eliminar(int clienteId)
        {
            return dClientes.EliminarClientes(clienteId);
        }
    }
}
