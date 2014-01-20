using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stefanini.Apoio.AIC.Negocio.DataTransport
{
    public class ProductsTO
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductSystemName { get; set; }
        public string ProductArea { get; set; }
        public string ProductHeader { get; set; }
        public int BusinessUnitID { get; set; }

    }
}
