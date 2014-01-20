using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stefanini.Apoio.AIC.Persistencia;
using System.IO;

namespace Stefanini.Apoio.AIC.UI.WEB.Controllers
{
    public class DiconController : Controller
    {

        public FileResult Proposta() 
        {

            return File(new MemoryStream(new DiconNegocio().ObtemProposta()), "application/pdf", string.Concat("Proposta_Dicon", DateTime.Now.ToString("HH:mm:ss"), ".pdf"));
        }

    }
}
