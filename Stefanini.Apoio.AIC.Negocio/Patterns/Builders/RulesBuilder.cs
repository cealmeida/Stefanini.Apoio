using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class RulesBuilder
    {
        private Guid ruleID;
        private Guid productID;
        private string expression;
        private string created;
        private string expires;
        private string ruleException;

        public RulesBuilder() 
        {
            this.created = DateTime.Now.ToString("yyyy/MM/dd");   
        }

        public RulesBuilder ComCodigo(Guid codigo) 
        {
            this.ruleID = codigo;
            return this;
        }

        public RulesBuilder ComCodigo()
        {
            this.ruleID = Guid.NewGuid();
            return this;
        }

        public RulesBuilder ParaProduto(Guid productID)
        {
            this.productID = productID;
            return this;
        }

        public RulesBuilder NaCondicao(String condicao)
        {
            this.expression = condicao;
            return this;
        }

        public RulesBuilder ExpiraEm(DateTime expiraEm)
        {
            this.expires = expiraEm.ToString("yyyy/MM/dd");
            return this;
        }

        public RulesBuilder ComMensagemDeErro(string mensagem)
        {
            this.ruleException = mensagem;
            return this;
        }

        public RulesTO Constroi() 
        {
            RulesTO regra = new RulesTO();
            regra.RuleID = this.ruleID;
            regra.ProductID = this.productID;
            regra.Expression = this.expression;
            regra.Created = this.created;
            regra.Expires = this.expires;
            regra.RuleException = this.ruleException;
            return regra;
        }
    }
}
