using CapaDatos.BaseDatos.Modelos;
using CapaDatos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DClientes
    {
        Repository<MClientes> _repository;

        public DClientes()
        {
            _repository = new Repository<MClientes>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<MClientes> TodosLosClientes()
        {
            return _repository.Consulta().ToList();

        }
        public int GuardarClientes(MClientes clientes)
        {
            if (clientes.ClienteId == 0)
            {
                _repository.Agregar(clientes);
                return 1;
            }
            else
            {
                var clientesInDb = _repository.Consulta().FirstOrDefault(c => c.ClienteId == clientes.ClienteId);
                if (clientesInDb != null)
                {
                    clientesInDb.Nombres = clientes.Nombres;
                    clientesInDb.Apellidos = clientes.Apellidos;
                    clientesInDb.Estado = clientes.Estado;
                    clientesInDb.FechaIngreso = clientes.FechaIngreso;
                    _repository.Editar(clientesInDb);
                    return 1;
                }

                return 0;
            }
        }
        public int EliminarClientes(int clienteId)
        {
            var clientesInDb = _repository.Consulta().FirstOrDefault(c => c.ClienteId == clienteId);
            if (clientesInDb != null)
            {
                _repository.Eliminar(clientesInDb);
                return 1;
            }
            return 0;
        }

    }
}
