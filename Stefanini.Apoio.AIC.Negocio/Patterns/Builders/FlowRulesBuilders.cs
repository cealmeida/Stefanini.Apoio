using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class FlowRulesBuilder
    {
        private Guid flowID;
        private Guid ruleID;
        private Guid flowRuleID;

        public FlowRulesBuilder() 
        {
            this.flowRuleID = Guid.NewGuid();
        }


        public FlowRulesBuilder DaRegra(Guid regra) 
        {
            this.ruleID = regra;
            return this;
        }

        public FlowRulesBuilder DoFluxo(Guid fluxo)
        {
            this.flowID = fluxo;
            return this;
        }

        public FlowRulesTO Constroi() 
        {
            FlowRulesTO flowRules = new FlowRulesTO();
            flowRules.FlowID = this.flowID;
            flowRules.FlowRuleID = this.flowRuleID;
            flowRules.RuleID = ruleID;
            return flowRules;
        }
    }
}
