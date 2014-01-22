using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stefanini.Apoio.AIC.Persistencia.Interface
{
    public interface IVidaEmpresarialRepositorio 
    {
        DataTable MontaReportDataSource();
    }
}
