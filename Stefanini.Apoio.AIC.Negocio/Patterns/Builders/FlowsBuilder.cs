using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class FlowsBuilder
    {
        private Guid flowID;
        private Guid productID;
        private Guid channelStepID;
        private String stepNumber;
        private IList<FlowRulesTO> flowRules;

        public FlowsBuilder() 
        {
            this.flowID = Guid.NewGuid();
            this.flowRules = new List<FlowRulesTO>();
        }

        public FlowsBuilder DoProduto(Guid codigoProduto) 
        {
            this.productID = codigoProduto;
            return this;
        }

        public FlowsBuilder DoChannelStep(Guid channelStepID)
        {
            this.channelStepID = channelStepID;
            return this;
        }

        public FlowsBuilder NaPosicaoDeNumero(int stepNumber)
        {
            this.stepNumber = stepNumber.ToString();
            return this;
        }

        public FlowsBuilder ComRegra(RulesTO rules) 
        {
            this.flowRules.Add(new FlowRulesBuilder().DaRegra(rules.RuleID).DoFluxo(this.flowID).Constroi());
            return this;
        }


        public FlowsTO Constroi() 
        {
            FlowsTO flowsTO = new FlowsTO();
            flowsTO.FlowID = this.flowID;
            flowsTO.ProductID = this.productID;
            flowsTO.ChannelStepID = this.channelStepID;
            flowsTO.StepNumber = this.stepNumber;
            return flowsTO;
        }

    }
}
