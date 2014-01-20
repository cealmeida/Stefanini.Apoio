using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia;
using Stefanini.Apoio.AIC.Persistencia.Repositorio;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Stefanini.Apoio.AIC.Persistencia.Interface
{
    public interface IDiconNegocio
    {

        byte[] ObtemProposta();
    }
}
