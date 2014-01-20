using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public class SqlUpdate:SqlInstruction
    {
        
       #region Atributos

        private SortedDictionary<string, string> colunas;

        #endregion

       #region Construtores

        public SqlUpdate() 
        {
            this.colunas = new SortedDictionary<string, string>();
        }
        #endregion

       #region Metodos
            #region Publicos

                    /// <summary>
                    /// Adiciona um binomio com nome da coluna e valor a ser inserido na mesma
                    /// </summary>
                    /// <param name="coluna">nome da coluna</param>
                    /// <param name="valor">valor da coluna </param>
                    public void setRowData(string coluna, object valor)
                    {
                        if (!(coluna.Length == 0 || valor is Nullable))
                        {
                            this.colunas.Add(coluna, this.TrataValor(valor));
                        }
                        else
                        {
                            this.colunas.Add(this.colunas.Keys.Count.ToString(), this.TrataValor(valor));
                        }
                    }

                    /// <summary>
                    /// Gera a string de instrução
                    /// </summary>
                    /// <returns></returns>
                    public override String GetInstruction()
                    {

                        String[] tempColunas = new String[this.colunas.Count];
                        
                        this.sql = String.Format("UPDATE FROM {0} SET ", this.Tabela);
                                               
                        for (int i = 0; i <= (this.colunas.Count - 1); i++)
                        {
                            tempColunas[i] = String.Format("{0} = {1}", this.colunas.Keys.ToArray()[i], this.colunas.Values.ToArray()[i]);
                        }
                        this.sql += String.Join(", ", tempColunas);

                        if (!(this.Criterio == null))
                        {
                            this.sql += String.Format(" WHERE {0} ", this.Criterio.Dump());
                        }
                        return string.Format("{0};", this.sql);
                    }

            #endregion
        #endregion
    }
}
