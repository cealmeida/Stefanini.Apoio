using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    internal class CrystalReportBuilder
    {
        private string arquivo;
        private DataTable dt;
        private IDictionary<string, object> parametros;

        public CrystalReportBuilder()
        {
            this.parametros = new Dictionary<string, object>();
        }

        public CrystalReportBuilder ComDataSoucer(DataTable dt)
        {
            this.dt = dt;
            return this;
        }

        public CrystalReportBuilder ComParametro(string nomeDoParametro, object valorDoParametro)
        {
            this.parametros.Add(nomeDoParametro, valorDoParametro);
            return this;
        }



        public CrystalReportBuilder ComArquivo(string arquivo)
        {
            this.arquivo = arquivo;
            return this;
        }

        public ReportDocument Constroi()
        {
            ReportDocument rpt = new ReportDocument();
            rpt.FileName = this.arquivo;
            rpt.SetDataSource(this.dt);


            foreach (var p in this.parametros)
            {
                rpt.SetParameterValue(p.Key, p.Value);
            }


            for (int i = 0; i <= rpt.Subreports.Count - 1; i++)
            {
                rpt.Subreports[i].SetDataSource(this.dt);
            }
            return rpt;
        }

       
    }
}
