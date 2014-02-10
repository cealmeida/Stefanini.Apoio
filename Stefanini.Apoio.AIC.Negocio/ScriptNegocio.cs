using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Stefanini.Apoio.AIC.Persistencia;

namespace Stefanini.Apoio.AIC.Negocio
{
    public class ScriptNegocio:IScriptNegocio
    {
        IDictionary<string, string> log = new Dictionary<string, string>();
         private IScriptRepositorio repositorio;
         private IScriptRepositorio Repositorio 
         {
             get 
             {
                 if (this.repositorio == null) 
                 {
                     this.repositorio = new ScriptRepositorio();
                 }
                 return this.repositorio;
             }
         }

         public IDictionary<string, string> Log
        {
            get{
                return this.log;
            }
        }

        public void Run(string diretorio) 
        {
            DirectoryInfo diretorioInfo = new DirectoryInfo(diretorio);
            foreach(DirectoryInfo d in diretorioInfo.GetDirectories()){
                this.Run(d.FullName);
            }

            FileInfo[] files = diretorioInfo.GetFiles("*.sql");
            foreach (var l in this.Repositorio.Run(files)) 
            {
                this.log.Add(l.Key, l.Value);
            }

        }
    }
}
