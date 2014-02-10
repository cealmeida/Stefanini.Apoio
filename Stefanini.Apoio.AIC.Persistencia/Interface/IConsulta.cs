using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stefanini.Apoio.AIC.Persistencia
{
    public interface IConsulta<T>
    {
        IEnumerable<T> Lista();
    }
}
