using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;
using Stefanini.Apoio.AIC.Negocio.Model;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class FluxoVendaBuilder
    {

        private ProductsTO produto;
        private ChannelsTO canal;
        private IList<StepsTO> steps;
        private IList<ChannelStepsTO> channelSteps;
        private IList<FlowsTO> flows;
        private IList<FlowRulesTO> flowRules;
        private IList<RulesTO> rules;
        private bool isNovoCanal;

        public FluxoVendaBuilder()
        {
            this.steps = new List<StepsTO>();
            this.channelSteps = new List<ChannelStepsTO>();
            this.flows = new List<FlowsTO>();
            this.flowRules = new List<FlowRulesTO>();
            this.rules = new List<RulesTO>();
        }



        public FluxoVendaBuilder DoProduto(ProductsTO produto)
        {
            this.produto = produto;
            return this;
        }

        public FluxoVendaBuilder DoProduto(Guid codigoProduto, string nome, string nomeDeSistema, string area, string cabecalho, int unidadeDeNegocio)
        {
            this.produto = new ProdutoBuilder().ComID(codigoProduto).DeNome(nome).ComNomeDeSistema(nomeDeSistema).DaArea(area).ComCabecalho(cabecalho).ComCodigoDaUnidadeDeNegocio(unidadeDeNegocio).Constroi();
            return this;
        }

        public FluxoVendaBuilder DoProduto(string codigoProduto, string nome, string nomeDeSistema, string area, string cabecalho, int unidadeDeNegocio)
        {
            this.DoProduto(Guid.Parse(codigoProduto), nome, nomeDeSistema, area, cabecalho, unidadeDeNegocio);
            return this;
        }

        public FluxoVendaBuilder DoProduto(string nome, string nomeDeSistema, string area, string cabecalho, int unidadeDeNegocio)
        {
            this.DoProduto(Guid.NewGuid(), nome, nomeDeSistema, area, cabecalho, unidadeDeNegocio);
            return this;
        }

        private FluxoVendaBuilder DoCanal(ChannelsTO channel, bool isNovoCanal)
        {
            this.canal = channel;
            this.isNovoCanal = isNovoCanal;
            return this;
        }

        public FluxoVendaBuilder ComCanalExistente(Guid codigo, string nomeCanal)
        {
            return this.DoCanal(new ChannelsBuilder().ComCodigo(codigo).ComName(nomeCanal).Constroi(), false);
            
        }

        public FluxoVendaBuilder ComCanalExistente(ChannelsTO channel)
        {
            return this.DoCanal(channel, false);
        }

        public FluxoVendaBuilder ComNovoCanal(string nomeCanal)
        {
            return this.DoCanal(new ChannelsBuilder().ComNovoID().ComName(nomeCanal).Constroi(), true);            
        }

        public FluxoVendaBuilder ComNovoCanal(ChannelsTO channel)
        {
            return this.DoCanal(channel, true);
        }
       
        public FluxoVendaBuilder ComStep(Guid stepID, string stepName, string stepsSytemName, int posicao)
        {
            StepsTO step = new StepsBuilder().ComID(stepID).DeNome(stepName).ComNomeDeSistema(stepsSytemName).Constroi();
            ChannelStepsTO channelSteps = new ChannelStepsBuilder().ComNovoID().DoCanal(this.canal.ChannelID).ComStep(step.StepID).Constroi();
            FlowsTO flows = new FlowsBuilder().DoProduto(this.produto.ProductID).DoChannelStep(channelSteps.ChannelStepID).NaPosicaoDeNumero(posicao).Constroi();
            this.steps.Add(step);
            this.channelSteps.Add(channelSteps);
            this.flows.Add(flows);
            return this;
        }        
        
        public FluxoVendaBuilder ComStep(Guid stepID, string stepName, string stepsSytemName, int posicao, Guid regra)
        {
            this.ComStep(stepID, stepName, stepsSytemName, posicao);
            this.flowRules.Add(new FlowRulesBuilder().DaRegra(regra).DoFluxo(this.flows.Last().FlowID).Constroi());
            return this;
        }

        public FluxoVendaBuilder ComStep(string stepName, string stepsSytemName, int posicao, Guid regra)
        {
            this.ComStep(Guid.NewGuid(), stepName, stepsSytemName, posicao);
            this.flowRules.Add(new FlowRulesBuilder().DaRegra(regra).DoFluxo(this.flows.Last().FlowID).Constroi());
            return this;
        }

        public FluxoVendaBuilder ComStep(string stepName, string stepsSytemName, int posicao, RulesTO regra)
        {
            this.ComStep(Guid.NewGuid(), stepName, stepsSytemName, posicao);
            this.flowRules.Add(new FlowRulesBuilder().DaRegra(regra.RuleID).DoFluxo(this.flows.Last().FlowID).Constroi());
            this.rules.Add(regra);
            return this;
        }

        public FluxoVendaBuilder ComStep(string stepName, string stepsSytemName, int posicao, string condicao, DateTime expriraEm, string mensagem)
        {
            this.ComStep(Guid.NewGuid(), stepName, stepsSytemName, posicao);
            RulesTO regra = new RulesBuilder().ComCodigo().ParaProduto(this.produto.ProductID).NaCondicao(condicao).ExpiraEm(expriraEm).ComMensagemDeErro(mensagem).Constroi();
            this.flowRules.Add(new FlowRulesBuilder().DaRegra(regra.RuleID).DoFluxo(this.flows.Last().FlowID).Constroi());
            this.rules.Add(regra);
            return this;
        }


        public FluxoVendaBuilder ComStep(string stepName, string stepsSytemName, int posicao)
        {
            return this.ComStep(Guid.NewGuid(), stepName, stepsSytemName, posicao);
        }

        

        public FluxoVendaModel Constroi()
        {
            FluxoVendaModel model = new FluxoVendaModel();
            model.Produto = this.produto;
            if (this.isNovoCanal)
            {
                model.Channels = this.canal;
            }
            model.Steps = this.steps;
            model.ChannelSteps = this.channelSteps;
            model.Flows = this.flows;
            model.FlowsRules = this.flowRules;
            model.Rules = this.rules;
            return model;
        }
    }
}
