using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DesignPattern.QueryObject
{
        /// <summary>
        /// Classe abstrata para gerenciar expressões
        /// </summary>
        public abstract class Expression
        {

            public enum Operador
            { 
                AND,
                OR
            }
           
            abstract public string Dump();


        }
    
}
