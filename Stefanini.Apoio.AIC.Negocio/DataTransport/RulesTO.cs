using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stefanini.Apoio.AIC.Negocio.DataTransport
{
    public class RulesTO
    {
        public Guid RuleID { get; set; }
        public Guid ProductID { get; set; }
        public string Expression { get; set; }
        public string Created { get; set; }
        public string Expires { get; set; }
        public string RuleException { get; set; }
    }
}
