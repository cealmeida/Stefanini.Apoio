using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{

        
    /// <summary>
    /// Provê uma interface utilizada para deficição de critérios
    /// </summary>
    public class Criteria:Expression
    {

        private List<Expression> expressions;
        private List<Operador> operadores;
      
        
        
        public Criteria()
        {
            this.expressions = new List<Expression>();
            this.operadores = new List<Operador>();
           
        }

        //public Criteria(params Expression[] ep):this()
        //{ 
        //    foreach(Expression exp in ep)
        //    {
        //        this.Add(exp);
        //    }
        
        //}

        /// <summary>
        /// Adiciona uma expressão ao critério
        /// </summary>
        /// <param name="expression">expressão</param>
        /// <param name="operador">operador logico de comparação</param>
        public void Add(Expression expression, Operador operador = Operador.AND)
        {
            if (this.expressions.Count > 0)
            {
                this.expressions.Add(expression);
                this.operadores.Add(operador);
            }
            else
            {
                this.expressions.Add(expression);
              
            }

        }

        public override string Dump()
        {
            String result = "(";
            if(this.expressions.Count > 0)
            {
                for (int i = 0; i <= (this.expressions.Count - 1); i++)
                {
                    if (this.operadores.Count > 0 && i > 0)
                    {
                        result += String.Format(" {0} {1} ", this.operadores[i-1].ToString(), this.expressions[i].Dump());
                    }
                    else 
                    {
                        result += String.Format(" {0} ", this.expressions[i].Dump());
                    }
                }
            }
            return result + ")";
        }

       
    }
}
