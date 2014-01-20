using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public class SqlFile
    {
        private IList<SqlInstruction> instrucoes;
        private string db;


        public SqlFile() 
        {
            this.instrucoes = new List<SqlInstruction>();
        }

        public SqlFile(string db) : this() 
        {
            this.db = db;
        }


        public void AddInstruction(SqlInstruction instrucao) 
        {
            if (instrucao != null)
            this.instrucoes.Add(instrucao);
        }


        public string CreateScript() 
        {
            StringBuilder script = new StringBuilder();
            foreach (var i in this.instrucoes) 
            {
                script.AppendLine(i.GetInstruction());
            }
            return script.ToString();
        }



    }
}
