using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Stefanini.Apoio.AIC.Persistencia.Class;
using Stefanini.Apoio.AIC.Persistencia.xsd;
using System.Data;


namespace Stefanini.Apoio.AIC.Repositorio
{
    [TestFixture]
    public class ReportDataSourceTest
    {
        [Test]
        public void DeveObterDataTableComDuasLinhas()
        {
            ReportDataSource rDS = new ReportDataSource();
            rDS.DoDataTable(new ConsorcioSchema().Tables[0]);
            DataTable dt = rDS.ObtemReportDataSource();
            Assert.NotNull(dt);
            Assert.AreEqual(2, dt.Rows.Count);
        }
    }
}
