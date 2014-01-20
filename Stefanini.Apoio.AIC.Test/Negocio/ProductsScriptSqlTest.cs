using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DesignPattern.QueryObject;
using Stefanini.Apoio.AIC.Negocio.DataTransport;

namespace Stefanini.Apoio.AIC.Negocio
{
    [TestFixture]
    public class ProductsScriptSqlTest
    {

        private const string QUERY_INSERT_PRODUTS = @"INSERT Products (ProductID, ProductName, ProductSystemName, ProductArea, ProductHeader, BusinessUnitID) VALUES ('2f51cfc5-04e5-4688-b775-da4c0c0afa60', 'Fácil Assistência Premiada', 'facilAssistenciaPremiada', 'Vida', 'SEG', 4);";



        [Test]
        public void DeveGerarStringInsertParaATabelaProduct()
        {

            ProductsTO produto = new ProdutoBuilder().ComID("2F51CFC5-04E5-4688-B775-DA4C0C0AFA60")
                                                    .DeNome("Fácil Assistência Premiada").ComNomeDeSistema("facilAssistenciaPremiada")
                                                    .DaArea("Vida").ComCabecalho("SEG")
                                                    .ComCodigoDaUnidadeDeNegocio(4).Constroi();                      

            SqlFile file = new SqlFile();
            SqlInsert insert = new SqlInsertBuilder().DoObjeto(produto).Constroi();
            file.AddInstruction(insert);
            string query = file.CreateScript();
            Assert.IsNotNullOrEmpty(query);
            Assert.AreEqual(QUERY_INSERT_PRODUTS, query.Trim());
        }
    }
}
