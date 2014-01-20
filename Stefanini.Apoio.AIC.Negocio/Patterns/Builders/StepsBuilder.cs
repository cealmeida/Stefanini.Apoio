using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class StepsBuilder
    {
        private Guid stepID;
        private string stepName;
        private string stepSystemName;
        private byte stepStatus = 1;
        private byte stepType = 0;
        private byte stepShared = 1;


        public StepsBuilder ComID(Guid stepID) 
        {
            this.stepID = stepID;
            return this;
        }

        public StepsBuilder ComNovoID()
        {
            this.stepID = Guid.NewGuid();
            return this;
        }

        public StepsBuilder DeNome(string stepName)
        {
            this.stepName = stepName;
            return this;
        }

        public StepsBuilder ComNomeDeSistema(string stepSystemName)
        {
            this.stepSystemName = stepSystemName;
            return this;
        }


        public StepsTO Constroi()
        {
            StepsTO steps = new StepsTO();
            steps.StepID = this.stepID;
            steps.StepName = this.stepName;
            steps.StepSystemName = this.stepSystemName;
            steps.StepStatus = this.stepStatus;
            steps.StepType = this.stepType;
            steps.StepShared = this.stepShared;
            return steps;
        }
    }
}
