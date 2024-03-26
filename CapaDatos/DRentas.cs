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
    public class DRentas
    {

        UnitOfWork _unitOfWork;

        public DRentas()
        {
            _unitOfWork = new UnitOfWork();
        }


        public int RentaId { get; set; }
        public int ClienteId { get; set; }
        public int PeliculaId { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaRetorno { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }


        public int Guardar(MRentas Rentas)
        {
            if (Rentas.RentaId == 0)
            {
                Rentas.FechaRenta = DateTime.Now;
                _unitOfWork.Repository<MRentas>().Agregar(Rentas);
                return _unitOfWork.Guardar();
            }
            else
            {
                var RentasInDb = _unitOfWork.Repository<MRentas>().Consulta().FirstOrDefault(c => c.RentaId == Rentas.RentaId);
                if (RentasInDb != null)
                {
                    RentasInDb.ClienteId = Rentas.ClienteId;
                    RentasInDb.PeliculaId = Rentas.PeliculaId;
                    RentasInDb.FechaRetorno = Rentas.FechaRetorno;
                    RentasInDb.Cantidad = Rentas.Cantidad;
                    RentasInDb.PrecioRenta = Rentas.PrecioRenta;
                    _unitOfWork.Repository<MRentas>().Editar(Rentas);
                    return _unitOfWork.Guardar();
                }

                return 0;
            }
        }

        public List<MRentas> TodaslasRentas()
        {

            return _unitOfWork.Repository<MRentas>().Consulta()
                                         .Include(c => c.MClientes)
                                         .Include(c => c.MPeliculas)
                                         .ToList();
        }

        public int Eliminar(int rentaId)
        {
            var RentasInDb = _unitOfWork.Repository<MRentas>().Consulta().FirstOrDefault(c => c.RentaId == rentaId);
            if (RentasInDb != null)
            {
                _unitOfWork.Repository<MRentas>().Eliminar(RentasInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}