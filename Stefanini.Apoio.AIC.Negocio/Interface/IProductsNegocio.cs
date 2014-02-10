using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio
{
    public interface IProductsNegocio
    {
        IEnumerable<ProductsTO> ListaProducts();
    }
}
