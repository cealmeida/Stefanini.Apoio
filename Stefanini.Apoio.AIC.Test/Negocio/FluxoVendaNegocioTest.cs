using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Stefanini.Apoio.AIC.Negocio.Interface;
using Stefanini.Apoio.AIC.Negocio.Model;
using Stefanini.Apoio.AIC.Negocio.Patterns.Builders;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio
{
    [TestFixture]
    public class FluxoVendaNegocioTest
    {

        private IFluxoVendaNegocio fluxoVenda;
       

        [SetUp]
        public void SetUp()
        {
            this.fluxoVenda = new FluxoVendaNegocio();           
        }

        [Test]
        public void DeveGerarScriptInsertComProduto()
        {
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4).Constroi();
            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);
        }

        [Test]
        public void NaoDeveGerarInstrucaoInsertVazio()
        {
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4).Constroi();
            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);
            Assert.IsFalse(script.Contains(string.Format("INSERT  () VALUES ();")));

        }

        [Test]
        public void NaoDeveGerarScriptInsertDeUmProdutoNulo()
        {
            try
            {
                FluxoVendaModel model = new FluxoVendaBuilder().Constroi();
                string script = this.fluxoVenda.GeraScriptSqlInsert(model);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void DeveGerarScriptInsertDeComCanal()
        {

            ChannelsTO channel = new ChannelsBuilder().ComNovoID().ComName("Balcao").Constroi();
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                    .ComNovoCanal(channel).Constroi();
            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);
            Assert.IsTrue(script.Contains(string.Format("INSERT Channels (ChannelID, ChannelName) VALUES ('{0}', '{1}')", channel.ChannelID, channel.ChannelName)));
        }
        
        [Test]
        public void DeveGerarScriptInsertComUmChannelSteps()
        {

            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                    .ComNovoCanal("Balcao").ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1).Constroi();
            ChannelStepsTO channelSteps = model.ChannelSteps.FirstOrDefault();
            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);
            Assert.IsNotNull(channelSteps);
            Assert.IsTrue(script.Contains(string.Format("INSERT ChannelSteps (ChannelStepID, ChannelID, StepID) VALUES ('{0}', '{1}', '{2}')", channelSteps.ChannelStepID, channelSteps.ChannelID, channelSteps.StepID)));

        }

        [Test]
        public void DeveGerarScriptInsertComUmaListaDeChannelSteps()
        {

            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                    .ComNovoCanal("Balcao").ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1).ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1).Constroi();

            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);

            foreach (ChannelStepsTO channelSteps in model.ChannelSteps)
            {
                Assert.IsTrue(script.Contains(string.Format("INSERT ChannelSteps (ChannelStepID, ChannelID, StepID) VALUES ('{0}', '{1}', '{2}')", channelSteps.ChannelStepID, channelSteps.ChannelID, channelSteps.StepID)));
            }

        }

        [Test]
        public void DeveGerarScriptInsertComUmChannelStepsDeUmNovoStep()
        {

            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                    .ComNovoCanal("Balcao").ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1).Constroi();

            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            Assert.IsNotEmpty(script);

            foreach (StepsTO step in model.Steps)
            {
                Assert.IsTrue(script.Contains(string.Format("INSERT Steps (StepID, StepName, StepSystemName, StepStatus, StepType, StepShared) VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5})", step.StepID, step.StepName, step.StepSystemName, step.StepStatus, step.StepType, step.StepShared)));
            }

            foreach (ChannelStepsTO channelSteps in model.ChannelSteps)
            {
                Assert.IsTrue(script.Contains(string.Format("INSERT ChannelSteps (ChannelStepID, ChannelID, StepID) VALUES ('{0}', '{1}', '{2}')", channelSteps.ChannelStepID, channelSteps.ChannelID, channelSteps.StepID)));
            }
        }

        [Test]
        public void DeveGerarScriptInsertFlows() 
        {
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                        .ComNovoCanal("Parceiros")
                                        .ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1)                                        
                                        .Constroi();

            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            FlowsTO flows = model.Flows.FirstOrDefault();
            Assert.IsNotEmpty(script);
            Assert.IsNotNull(flows);
            Assert.IsTrue(script.Contains(string.Format("INSERT Flows (FlowID, ProductID, ChannelStepID, StepNumber) VALUES ('{0}', '{1}', '{2}', '{3}');", flows.FlowID, flows.ProductID, flows.ChannelStepID, flows.StepNumber)));

        }

        [Test]
        public void DeveGerarScriptInsertFlowsRules()
        {
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                        .ComNovoCanal("Parceiros")
                                        .ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1, Guid.NewGuid())
                                        .Constroi();

            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            FlowRulesTO flowsRules = model.FlowsRules.FirstOrDefault();
            Assert.IsNotEmpty(script);
            Assert.IsNotNull(flowsRules);
            Assert.IsTrue(script.Contains(string.Format("INSERT FlowRules (FlowID, RuleID, FlowRuleID) VALUES ('{0}', '{1}', '{2}');", flowsRules.FlowID, flowsRules.RuleID, flowsRules.FlowRuleID)));

        }

        [Test]
        public void DeveGerarScriptInsertParaRules()
        {
            FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60", "Fácil Assistência Premiada", "facilAssistenciaPremiada", "Vida", "SEG", 4)
                                        .ComNovoCanal("Parceiros")
                                        .ComStep("facilAssistenciaPremiada", "facilAssistenciaPremiada", 1, " iptIdade > 23", DateTime.Now.AddYears(10), "Não está dentro do limite de idade.")
                                        .Constroi();

            string script = this.fluxoVenda.GeraScriptSqlInsert(model);
            RulesTO regra = model.Rules.FirstOrDefault();
            Assert.IsNotEmpty(script);
            Assert.IsNotNull(regra);
            Assert.IsTrue(script.Contains(string.Format("INSERT Rules (RuleID, ProductID, Expression, Created, Expires, RuleException) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}'", 
                                                            regra.RuleID, regra.ProductID, regra.Expression, 
                                                            regra.Created, regra.Expires, regra.RuleException)));
        }

        [Test]
        public void DeveExecutarScriptNaBaseDeDados() 
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=STFBSBBD02\STEFANINI_BSB;Initial Catalog=AIC_Config;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                connection.Open();
                System.Data.SqlClient.SqlTransaction trasation = connection.BeginTransaction();
                try
                {
                    
                    FluxoVendaModel model = new FluxoVendaBuilder().DoProduto("3EC51EEA-439A-4287-A9D6-7F899828F346", "Fácil Gerador de Script Premiado", "facilGeradorDeScriptPremiada", "Vida", "SEG", 10)
                                            .ComCanalExistente(Guid.Parse("B3B7781C-A32E-4F8F-A2D2-53AFACF514AD"), "Parceiros")
                                            .ComStep("Gerador de Script", "Gerador de Script", 1, " iptIdade > 23", DateTime.Now.AddYears(10), "Não está dentro do limite de idade.")
                                            .Constroi();
                    string script = this.fluxoVenda.GeraScriptSqlInsert(model);


                    System.Data.SqlClient.SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = script;
                    cmd.Transaction = trasation;
                    int numeroDeLinhasAfetadas = cmd.ExecuteNonQuery();
                    Assert.AreNotEqual(0, numeroDeLinhasAfetadas);

                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
                finally 
                {
                    trasation.Rollback();
                }
            }

        }

    }
}
