using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using Stefanini.Apoio.AIC.Negocio;

namespace Stefanini.Apoio.AIC.UI.WEB.Controllers
{
    public class VidaEmpresarialController : Controller
    {
        //
        // GET: /VidaEmpresarial/

        public ActionResult Proposta()
        {
            return File(new MemoryStream(new VidaEmpresarialNegocio().ObtemProposta()), "application/pdf", string.Concat("Proposta_Vida", DateTime.Now.ToString("HH:mm:ss"), ".pdf"));
        }

    }
}
