using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stefanini.Apoio.AIC.Persistencia
{
    public class ReportDataSource
    {

        private int[] id_via = { 1, 2 };
        private string[] nm_descricao = { "1ª via - Consorciado", "2ª via - Administradora" };
        private bool comVias = true;
        private IDictionary<string, string> colunas = new Dictionary<string, string>();
        private DataTable dt;


        public ReportDataSource DoDataTable(DataTable dt)
        {
            this.dt = dt;
            return this;
        }

        public ReportDataSource ComVias()
        {
            this.comVias = true;
            return this;
        }


        public ReportDataSource SemVias()
        {
            this.comVias = false;
            return this;
        }

        public ReportDataSource ComColunaDeValor(string coluna, string valor)
        {
            this.colunas.Add(coluna, valor);
            return this;
        }


        public DataTable ObtemReportDataSource()
        {
            if (this.comVias)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.dt.Rows.Add(this.dt.NewRow());
                    this.dt.Rows[i]["id_via"] = this.id_via[i];
                    this.dt.Rows[i]["nm_descricao"] = this.nm_descricao[i];
                    foreach (var coluna in this.colunas)
                    {
                        this.dt.Rows[i][coluna.Key] = coluna.Value;
                    }

                }
            }
            else
            {
                this.dt.Rows.Add(this.dt.NewRow());
                foreach (var coluna in this.colunas)
                {
                    this.dt.Rows[0][coluna.Key] = coluna.Value;
                }
            }
            return this.dt;

        }






    }
}
