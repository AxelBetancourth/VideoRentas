using CapaDatos.BaseDatos.Modelos;
using CapaDatos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPeliculas
    {
        UnitOfWork _unitOfWork;

        public DPeliculas()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Autores { get; set; }
        public int Existencia { get; set; }
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }

        public List<MPeliculas> TodasLasPeliculas()
        {
            return _unitOfWork.Repository<MPeliculas>().Consulta().ToList();
        }
        public int Guardar(MPeliculas peliculas)
        {
            if (peliculas.PeliculaId == 0)
            {
                _unitOfWork.Repository<MPeliculas>().Agregar(peliculas);
                return _unitOfWork.Guardar();
            }
            else
            {
                var PeliculasInDb = _unitOfWork.Repository<MPeliculas>().Consulta().FirstOrDefault(c => c.PeliculaId == peliculas.PeliculaId);
                if (PeliculasInDb != null)
                {
                    PeliculasInDb.Nombre = peliculas.Nombre;
                    PeliculasInDb.Genero = peliculas.Genero;
                    PeliculasInDb.Autores = peliculas.Autores;
                    PeliculasInDb.Existencia = peliculas.Existencia;
                    PeliculasInDb.PrecioRenta = peliculas.PrecioRenta;
                    PeliculasInDb.Estado = peliculas.Estado;
                    _unitOfWork.Repository<MPeliculas>().Editar(peliculas);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public MPeliculas ObtenerPeliculaPorId(int peliculaId)
        {
            return _unitOfWork.Repository<MPeliculas>().Consulta().FirstOrDefault(c => c.PeliculaId == peliculaId);
        }
        public int EliminarPeliculas(int peliculaid)
        {
            var PeliculasInDb = _unitOfWork.Repository<MPeliculas>().Consulta().FirstOrDefault(c => c.PeliculaId == peliculaid);
            if (PeliculasInDb != null)
            {
                _unitOfWork.Repository<MPeliculas>().Eliminar(PeliculasInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
