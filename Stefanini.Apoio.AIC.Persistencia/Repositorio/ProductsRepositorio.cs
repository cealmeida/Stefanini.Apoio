using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia;
using Stefanini.Apoio.AIC.Persistencia.Model;

namespace Stefanini.Apoio.AIC.Persistencia.Repositorio
{
    public class ProductsRepositorio : IProductsRepositorio
    {
        public IEnumerable<Model.Products> Lista()
        {

            IEnumerable<Model.Products> produtos = null;

            using (AIC_Config db = new AIC_Config()) 
            {
                produtos = db.Products.Select( p => p);
            }

            return produtos;


        }
    }
}
