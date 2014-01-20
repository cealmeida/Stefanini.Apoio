using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DesignPattern.QueryObject
{
    public class SqlInsert : SqlInstruction
    {

        #region Atributos

        private IDictionary<string, string> colunas;

        public override Criteria Criterio
        {
            get
            {
                throw new Exception("Essa classe não possui essa propriedade");
            }
            set
            {
                throw new Exception("Essa classe não possui essa propriedade");
            }
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Retorna uma string com as colunas da instrução
        /// </summary>
        public virtual String Colunas
        {
            get { return String.Join(", ", this.colunas.Keys.ToArray()); }
        }

        /// <summary>
        /// Retorno uma string com os valores das colunas da instrução
        /// </summary>
        public virtual String Valores
        {
            get { return String.Join(", ", this.colunas.Values.ToArray()); }
        }

        #endregion

        #region Construtores
        public SqlInsert()
        {
            this.colunas = new Dictionary<string, string>();
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Adiciona um binomio com nome da coluna e valor a ser inserido na mesma
        /// </summary>

        /// <param name="valor">valor da coluna </param>
        public void setRowData(object valor)
        {
            this.setRowData(this.colunas.Keys.Count.ToString(), valor);
        }

        /// <summary>
        /// Adiciona um binomio com nome da coluna e valor a ser inserido na mesma
        /// </summary>
        /// <param name="coluna">nome da coluna</param>
        /// <param name="valor">valor da coluna </param>
        public void setRowData(string coluna, object valor)
        {
            this.colunas.Add(coluna, this.TrataValor(valor));
        }

        /// <summary>
        /// Gera a string de instrução
        /// </summary>
        /// <returns></returns>
        public override String GetInstruction()
        {

            return String.Format("INSERT {0} ({1}) VALUES ({2});", this.Tabela, this.Colunas, this.Valores);
        }


        #endregion

    }
}
