using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public class SqlInsertBuilder
    {

        private IDictionary<string, object> rows;
        private string tabela;

        public SqlInsertBuilder()
        {
            this.rows = new Dictionary<string, object>();
        }

        public SqlInsertBuilder DaTabela(string tabela)
        {
            this.tabela = tabela;
            return this;
        }

        public SqlInsertBuilder DoObjeto(Object obj)
        {
            if (obj != null)
            {
                ObjectPropertyInterator interator = new ObjectPropertyInterator(obj);
                this.tabela = obj.GetType().Name.Replace("TO", "");
                while (interator.HasRow)
                {
                    this.rows.Add(interator.NextRow());
                }
            }
            return this;
        }


        public SqlInsert Constroi()
        {
            if (string.IsNullOrWhiteSpace(this.tabela) == false && (this.rows != null && this.rows.Count > 0))
            {
                SqlInsert insert = new SqlInsert();
                insert.Tabela = this.tabela;
                foreach (var row in this.rows)
                {
                    insert.setRowData(row.Key, row.Value);
                }
                return insert;
            }

            return null;       
        }

    }
}
