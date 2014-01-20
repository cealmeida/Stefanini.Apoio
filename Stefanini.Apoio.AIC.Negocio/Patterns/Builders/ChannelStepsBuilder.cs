using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class ChannelStepsBuilder
    {
        private Guid channelStepID;
        private Guid channelID;
        private Guid stepID;


        public ChannelStepsBuilder ComNovoID() 
        {
            this.channelStepID = Guid.NewGuid();
            return this;
        }

        public ChannelStepsBuilder ComChannelStepID(Guid codigo)
        {
            this.channelStepID = codigo;
            return this;
        }

        public ChannelStepsBuilder DoCanal(Guid codigoCanal)
        {
            this.channelID = codigoCanal;
            return this;
        }

        public ChannelStepsBuilder ComStep(Guid codigoStep)
        {
            this.stepID = codigoStep;
            return this;
        }


        public ChannelStepsTO Constroi() 
        {
            ChannelStepsTO channelStepsTO = new ChannelStepsTO();

            channelStepsTO.ChannelStepID = this.channelStepID;
            channelStepsTO.ChannelID = this.channelID;
            channelStepsTO.StepID = this.stepID;

            return channelStepsTO;
        }
    }
}
