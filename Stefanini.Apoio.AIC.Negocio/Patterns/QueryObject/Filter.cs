using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{

    /// <summary>
    /// Provê uma interface para definição de filtros de seleção
    /// </summary>
    public class Filter: Expression
    {
        private string variavel;
        private string operador;
        private string valor;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="variavel">Variavel</param>
        /// <param name="operador">operador >, \> </param>
        /// <param name="valor">valor a ser comparado</param>
        public Filter(string variavel, string operador, Object valor)
        {
            this.variavel = variavel.ToUpper();
            this.operador = operador.ToUpper();
            this.valor = this.Transform(valor);
        }

        /// <summary>
        /// Recebe um valor e faz modificações necessarias para ele ser interpretado pelo banco de dados
        /// podendo ser um integer/string/boolean/ ou array
        /// </summary>
        /// <param name="valor">valor a ser transformado</param>
        /// <returns></returns>
        private string Transform(object valor) 
        {
            String result = "";
            if(valor is Array)
            {
                List<String> temp = new List<String>();
                foreach (object v in (Array) valor)
                {
                    if (v is Int16)
                    {
                        temp.Add((String) v);
                    }
                    else if (v is String)
                    {
                        temp.Add(String.Format("'{0}'", (String) v));
                    }

                }
                result = String.Format("({0})",String.Join(",", temp.ToArray()));
            }
            else if(valor is string)
            {
                result = String.Format("'{0}'",valor);
            }
            else if (valor is Nullable)
            {
                result = "'NULL'";
            }
            else if (valor is Boolean)
            {
                result = ((Boolean)valor ? "'TRUE'" : "'FALSE'");
            }
            else if (valor is SqlSelect)
            {
                result = String.Format("({0})", ((SqlSelect)valor).GetInstruction());
            }
            else
            {
                result = valor.ToString();
            }
            return result;
        }

       public override string Dump()
        {
            return String.Format("{0} {1} {2}",this.variavel.ToUpper(), this.operador, this.valor);
        }
    }
}
