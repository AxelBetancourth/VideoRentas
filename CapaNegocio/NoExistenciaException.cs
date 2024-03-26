using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NoExistenciaException : Exception
    {
        public NoExistenciaException() : base() { }

        public NoExistenciaException(string message) : base(message) { }

        public NoExistenciaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
