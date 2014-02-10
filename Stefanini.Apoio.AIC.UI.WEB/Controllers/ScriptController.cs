using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stefanini.Apoio.AIC.Negocio;

namespace Stefanini.Apoio.AIC.UI.WEB.Controllers
{
    public class ScriptController : Controller
    {
        
        public ActionResult Index()
        {
            if (TempData.ContainsKey("log")) 
            {
                ViewBag.Resultado = TempData["log"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Run(FormCollection forms) 
        {
            ScriptNegocio negocio = new ScriptNegocio();
            negocio.Run(forms["txtDiretorio"]);
            TempData["log"] = negocio.Log;
            return RedirectToAction("Index");
        }

    }
}
