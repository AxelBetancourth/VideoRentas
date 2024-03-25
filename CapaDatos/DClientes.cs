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

        UnitOfWork _unitOfWork;

        public DClientes()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<MClientes> TodosLosClientes()
        {
            return _unitOfWork.Repository<MClientes>().Consulta().ToList();
        }
        public int Guardar(MClientes clientes)
        {
            if (clientes.ClienteId == 0)
            {
                _unitOfWork.Repository<MClientes>().Agregar(clientes);
                return _unitOfWork.Guardar();
            }
            else
            {
                var clientesInDb = _unitOfWork.Repository<MClientes>().Consulta().FirstOrDefault(c => c.ClienteId == clientes.ClienteId);
                if (clientesInDb != null)
                {
                    clientesInDb.Nombres = clientes.Nombres;
                    clientesInDb.Apellidos = clientes.Apellidos;
                    clientesInDb.Estado = clientes.Estado;
                    _unitOfWork.Repository<MClientes>().Editar(clientes);
                    return _unitOfWork.Guardar();
                }

                return 0;
            }
        }
        public int Eliminar(int clienteId)
        {
            var clientesInDb = _unitOfWork.Repository<MClientes>().Consulta().FirstOrDefault(c => c.ClienteId == clienteId);
            if (clientesInDb != null)
            {
                _unitOfWork.Repository<MClientes>().Eliminar(clientesInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

    }
}
