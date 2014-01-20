using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia.Repositorio;
using System.IO;
using Stefanini.Apoio.AIC.Persistencia.Interface;

namespace Stefanini.Apoio.AIC.Persistencia
{
    public class DiconNegocio:IDiconNegocio
    {
        private IDiconRepositorio repositorio;

        private IDiconRepositorio Repositorio
        {
            get
            {

                if (this.repositorio == null)
                {
                    this.repositorio = new DiconRepositorio();
                }

                return this.repositorio;
            }
        }

        public byte[] ObtemProposta()
        {
            byte[] arquivoPDF = null;

            Stream sm = new CrystalReportBuilder()
                                .ComArquivo(Path.Combine(@"C:\Users\zbraga\Documents\Visual Studio 2010\Projects\Stefanini.Apoio.AIC\Stefanini.Apoio.AIC.Negocio\rpt", "Consorcio.rpt"))
                                .ComDataSoucer(this.Repositorio.MontaDataSourceDicon())
                                .Constroi().ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            using (MemoryStream ms = new MemoryStream())
            {
                sm.CopyTo(ms);
                arquivoPDF = ms.ToArray();
            }

            return arquivoPDF;
        }
    }
}
