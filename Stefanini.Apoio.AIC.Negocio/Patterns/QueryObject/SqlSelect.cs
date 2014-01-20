using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public class SqlSelect:SqlInstruction
    {
        #region Enumerados
            private enum Propriedades
            { 
                ORDER_BY,
                HAVING,
                GROUP_BY,
                TOP
            }
        #endregion

        #region Atributos

        private List<String> colunas;
        private string sql;
        private SortedDictionary<Propriedades, object> propriedades;

        #endregion

        #region Propriedades

            /// <summary>
            /// Define a Clausula Having para a consulta
            /// </summary>
  
            public Criteria Having
            {
                set {
                    this.propriedades.Add(Propriedades.HAVING,value);
                }
            }
            
            /// <summary>
            /// Define a Clausula Order by para a consulta
            /// </summary>
            public String OrderBy 
            {
                set
                {
                    this.propriedades.Add(Propriedades.ORDER_BY, value);
                }
            }

            /// <summary>
            /// Define a Clausula Group by para a consulta
            /// </summary>
            public bool GroupBy 
            {
                set
                {
                    this.propriedades.Add(Propriedades.GROUP_BY, value);
                }
            }

            /// <summary>
            /// Define a Clausula Top para a consulta
            /// </summary>
            public Int64 Top
            {
                set 
                {
                    this.propriedades.Add(Propriedades.TOP, value);
                }
            }

        #endregion

        #region Construtores

        public SqlSelect() {
            this.colunas = new List<string>();
            this.propriedades = new SortedDictionary<Propriedades, object>();
        }

        public SqlSelect(string tabela, Criteria criterio, params string[] colunas):this()
        {
            this.Tabela = tabela;
            this.Criterio = criterio;
            foreach (string c in colunas)
            {
                this.colunas.Add(c);
            }
        }
        
        public SqlSelect(string tabela, Criteria criterio): this()
        {
            this.Tabela = tabela;
            this.Criterio = criterio;
            
        }

        #endregion
        
        #region Metodos
        #region Privados
            private String GetPropriedade()
            {
                string orderby = "";
                string having = ""; // condição do agrupamento
                string groupby = "";
                
                foreach(KeyValuePair<Propriedades, object> value in this.propriedades)
                {
                    switch (value.Key)
                    {
                        case Propriedades.ORDER_BY:
                            break;
                        case Propriedades.HAVING:
                            break;
                        case Propriedades.GROUP_BY:
                            break;
                        default:
                            break;
                    }
                }
                return "";
            }
        #endregion
        #region Publicos


        /// <summary>
        /// Adiciona uma coluna a ao select
        /// </summary>
        /// <param name="coluna">Coluna a ser adicionada</param>
        public void AddColuna(String coluna) {
                if (coluna.Length > 0)
                {
                    this.colunas.Add(coluna);
                }
        }

        /// <summary>
        /// Adiciona uma coluna ao select
        /// </summary>
        /// <param name="coluna">Lista de colunas a serem inseridas</param>
        public void AddColuna(params String[] coluna)
        {
            if (coluna.Length > 0)
            {
                for(int i = 0; i < (coluna.Length - 1);i++){
                    this.colunas.Add(coluna[i]);
                }
            }
        }

        public override string GetInstruction()
                    {
                        this.sql = "SELECT ";
                        if (this.colunas.Count > 0)
                        {
                            this.sql += String.Join(",", this.colunas.ToArray());

                        }
                        else
                        {
                            this.sql += " * ";
                        }
                        this.sql += string.Format(" FROM {0} ", this.Tabela);
                        if (this.Criterio != null)
                        {
                            this.sql += this.Criterio.Dump();
                        }
                        return string.Format("{0};",this.sql);
                    }

            #endregion
        #endregion
       
    }
}
