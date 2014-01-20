using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Negocio.DataTransport;


namespace Stefanini.Apoio.AIC.Negocio
{
    public class ProdutoBuilder
    {
        private Guid ProductId { get; set; }
        private string ProductName { get; set; }
        private string ProductSystemName { get; set; }
        private string ProductArea { get; set; }
        private string ProductHeader { get; set; }
        private int BusinessUnitID { get; set; }


        public ProdutoBuilder ComNewID() 
        {
            this.ProductId = Guid.NewGuid();
            return this;
        }

        public ProdutoBuilder ComID(Guid guid)
        {
            this.ProductId = guid;
            return this;
        }

        public ProdutoBuilder ComID(string guid)
        {
            this.ProductId = Guid.Parse(guid);
            return this;
        }

        public ProdutoBuilder DeNome(string nome) 
        {
            this.ProductName = nome;
            return this;
        }

        public ProdutoBuilder ComNomeDeSistema(string nomeDeSistema) 
        {
            this.ProductSystemName = nomeDeSistema;
            return this;
        }

        public ProdutoBuilder DaArea(string area) 
        {
            this.ProductArea = area;
            return this;
        }

        public ProdutoBuilder ComCabecalho(string cabecalho) 
        {
            this.ProductHeader = cabecalho;
            return this;
        }

        public ProdutoBuilder ComCodigoDaUnidadeDeNegocio(int unidadeDeNegocio)
        {
            this.BusinessUnitID = unidadeDeNegocio;
            return this;
        }

        public ProductsTO Constroi()
        {
            ProductsTO to = new ProductsTO();
            to.ProductID = this.ProductId;
            to.ProductName = this.ProductName;
            to.ProductSystemName = this.ProductSystemName;
            to.ProductArea = this.ProductArea;
            to.ProductHeader = this.ProductHeader;
            to.BusinessUnitID = this.BusinessUnitID;

            return to;
        }
    }
}
