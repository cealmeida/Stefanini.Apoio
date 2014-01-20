using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio.Patterns.Builders
{
    public class ChannelsBuilder
    {
        private Guid channelID;
        private string channelName;

        public ChannelsBuilder ComNovoID() 
        {
            this.channelID = Guid.NewGuid();
            return this;
        }

        public ChannelsBuilder ComCodigo(Guid codigo)
        {
            this.channelID = codigo;
            return this;
        }

        public ChannelsBuilder ComName(string nome) 
        {
            this.channelName = nome;
            return this;
        }

        public ChannelsTO Constroi() 
        {
            ChannelsTO to = new ChannelsTO();
            to.ChannelID = this.channelID;
            to.ChannelName = this.channelName;
            return to;

        }
    }
}
