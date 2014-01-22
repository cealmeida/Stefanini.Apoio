using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia.Repositorio;
using System.IO;
using Stefanini.Apoio.AIC.Negocio;
using Stefanini.Apoio.AIC.Negocio.Interface;
using Stefanini.Apoio.AIC.Persistencia.Interface;
using Stefanini.Apoio.AIC.Negocio.Patterns.Builders;

namespace Stefanini.Apoio.AIC.Negocio
{
    public class VidaEmpresarialNegocio : IVidaEmpresarialNegocio
    {
        private IVidaEmpresarialRepositorio repositorio;

        private IVidaEmpresarialRepositorio Repositorio
        {
            get
            {

                if (this.repositorio == null)
                {
                    this.repositorio = new VidaEmpresarialRepositorio();
                }

                return this.repositorio;
            }
        }

        public byte[] ObtemProposta()
        {
            byte[] arquivoPDF = null;

            Stream sm = new CrystalReportBuilder()
                                .ComArquivo(Path.Combine(@"C:\Users\manasciomento\Desktop\qualquer coisa\Stefanini.Apoio.AIC\Stefanini.Apoio.AIC.Negocio\rpt", "VidaEmpresarial.rpt"))
                                .ComDataSoucer(this.Repositorio.MontaReportDataSource())
                                .ComParametro("iptTipoPagamento", "4")
                                .ComParametro("Pm-Comando.id_via", 1)
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
