using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.Interface;
using DesignPattern.QueryObject;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio
{
    public class FluxoVendaNegocio : IFluxoVendaNegocio, IFluxoVendaAPrazo
    {

        public string GeraScriptSqlInsert(Model.FluxoVendaModel fluxoVenda)
        {
            SqlFile file = new SqlFile();           
           
            
            file.AddInstruction(new SqlInsertBuilder().DoObjeto(fluxoVenda.Produto).Constroi());   
      
            file.AddInstruction(new SqlInsertBuilder().DoObjeto(fluxoVenda.Channels).Constroi());

            foreach (StepsTO steps in fluxoVenda.Steps)
            {
                file.AddInstruction(new SqlInsertBuilder().DoObjeto(steps).Constroi());
            }

            foreach (ChannelStepsTO channelSteps in fluxoVenda.ChannelSteps)
            {
                file.AddInstruction(new SqlInsertBuilder().DoObjeto(channelSteps).Constroi());
            }

            foreach (FlowsTO flows in fluxoVenda.Flows)
            {
                file.AddInstruction(new SqlInsertBuilder().DoObjeto(flows).Constroi());
            }

            foreach (RulesTO regra in fluxoVenda.Rules)
            {
                file.AddInstruction(new SqlInsertBuilder().DoObjeto(regra).Constroi());
            }


            foreach (FlowRulesTO flowRulesTO in fluxoVenda.FlowsRules)
            {
                file.AddInstruction(new SqlInsertBuilder().DoObjeto(flowRulesTO).Constroi());
            }




            return file.CreateScript();
        }

       

        public void FluxoPraxo()
        {
            throw new NotImplementedException();
        }
    }
}
