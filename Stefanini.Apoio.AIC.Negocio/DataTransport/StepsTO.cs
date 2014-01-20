using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stefanini.Apoio.AIC.Negocio.DataTransport
{
    public class StepsTO
    {
        public Guid StepID { get; set; }
        public string StepName { get; set; }
        public string StepSystemName { get; set; }
        public byte StepStatus { get; set; }
        public byte StepType { get; set; }
        public byte StepShared { get; set; }
    }
}
