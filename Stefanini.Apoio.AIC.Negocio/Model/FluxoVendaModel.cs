using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Model
{
    public class FluxoVendaModel
    {

        public ProductsTO Produto { get; set; }
        public ChannelsTO Channels { get; set; }
        public IList<StepsTO> Steps { get; set; }
        public IList<ChannelStepsTO> ChannelSteps { get; set; }
        public IList<FlowsTO> Flows { get; set; }
        public IList<FlowRulesTO> FlowsRules { get; set; }
        public IList<RulesTO> Rules { get; set; }

    }
}
