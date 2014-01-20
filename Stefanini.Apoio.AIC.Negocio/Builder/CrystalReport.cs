using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Stefanini.Apoio.AIC.Persistencia
{
    internal class CrystalReportBuilder
    {

        private string arquivo;
        private DataTable dt;


        public CrystalReportBuilder ComDataSoucer(DataTable dt) 
        {
            this.dt = dt;
            return this;
        }

        public CrystalReportBuilder ComArquivo(string arquivo) 
        {
            this.arquivo = arquivo;
            return this;
                
        }

        public ReportClass Constroi() 
        {
            ReportClass rpt = new ReportClass();
            rpt.FileName = this.arquivo;
            rpt.SetDataSource(this.dt);           
            for(int i = 0; i <= rpt.Subreports.Count - 1; i++){
                rpt.Subreports[i].SetDataSource(this.dt);
            }
            return rpt;
        }

       
    }
}
