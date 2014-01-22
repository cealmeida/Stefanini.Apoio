using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia;
using Stefanini.Apoio.AIC.Persistencia.Repositorio;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Stefanini.Apoio.AIC.Negocio.Interface
{
    public interface IVidaEmpresarialNegocio
    {

        byte[] ObtemProposta();
    }
}
