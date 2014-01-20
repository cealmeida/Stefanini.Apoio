using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public abstract class SqlInstruction
    {

        #region Atributos de Classe

        protected string sql;
       
        #endregion

        #region Propriedades

            /// <summary>
        /// Retorna e altera a tabela da consulta
        /// </summary>
            public String Tabela { get; set; }

            /// <summary>
        /// Altera e retorna o criterio da consulta
        /// </summary>
            public virtual Criteria Criterio { get; set; }

           
        #endregion

        #region Metodos

            #region Internos

            protected String TrataValor(object valor)
            {
                string valorTratado = "";
                if (valor is string || valor is DateTime || valor is Guid)
                {
                    valorTratado = String.Format("'{0}'", valor.ToString().Replace("'", "").Replace("\"", ""));
                }
                else if (valor is bool)
                {
                   valorTratado = ((Boolean)valor ? "'TRUE'" : "'FALSE'");
                }
                else if (valor.ToString().IsNumeric())
                {
                    valorTratado = valor.ToString();
                }
                return valorTratado.Trim();
            }

           
            #endregion

            #region Publicos
                
                /// <summary>
                /// Método abstrato para gerar uma string com a instrução sql
                /// </summary>
                /// <returns>String</returns>
                abstract public String GetInstruction();

            #endregion

        #endregion
          
    }
}
