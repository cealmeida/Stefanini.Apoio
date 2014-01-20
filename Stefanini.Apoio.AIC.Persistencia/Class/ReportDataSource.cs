using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stefanini.Apoio.AIC.Persistencia.Class
{
    public class ReportDataSource
    {

        private int[] id_via = { 1, 2 };
        private string[] nm_descricao = { "1ª via - Consorciado", "2ª via - Administradora" };
        private IDictionary<string, string> colunas = new Dictionary<string, string>(); 
        private DataTable dt;


        public void DoDataTable(DataTable dt) 
        {
            this.dt = dt;
        }

       
        public void ComColunaDeValor(string coluna, string valor)
        {
            this.colunas.Add(coluna, valor);
        }

        public DataTable ObtemReportDataSource() 
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
            return this.dt;

        }

       




    }
}
