using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.Model;

namespace Stefanini.Apoio.AIC.Negocio.Interface
{
    public interface IFluxoVendaNegocio
    {

        string GeraScriptSqlInsert(FluxoVendaModel fluxoVenda);
    }
}
