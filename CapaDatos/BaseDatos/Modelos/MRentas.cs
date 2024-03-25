using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.BaseDatos.Modelos
{
    public class MRentas
    {

        [Key]
        public int RentaId { get; set; }
        public int ClienteId { get; set; }
        public MClientes MClientes { get; set; }
        public int PeliculaId { get; set; }
        public MPeliculas MPeliculas { get; set; }
        [Required]
        public DateTime FechaRenta { get; set; }
        [Required]
        public DateTime FechaRetorno { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }
    }
}
