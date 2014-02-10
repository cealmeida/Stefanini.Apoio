using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Stefanini.Apoio.AIC.Persistencia
{
    public class ScriptRepositorio : IScriptRepositorio
    {



        public IDictionary<string, string> Run(System.IO.FileInfo[] files)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            foreach(var file in files)
            {
                /*Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = "sqlcmd.exe";
                process.StartInfo.Arguments = string.Format("-S {0} -d {1} -i \"{2}\"", "STFBSBBD02\\STEFANINI_BSB", "AIC_CONFIG", file.FullName);
                process.StartInfo.WorkingDirectory = @"C:\";
                process.Start();*/

                ProcessStartInfo info = new ProcessStartInfo("cmd", string.Format(@"/c sqlcmd -S {0} -d {1} -i {2}", "STFBSBBD02\\STEFANINI_BSB", "AIC_CONFIG", file.FullName.Replace(" ","_")));
                
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;               
                info.CreateNoWindow = true;                
                Process p = new Process();
                p.StartInfo = info;
                p.Start();             
                                
                resultado.Add(file.FullName, p.StandardOutput.ReadToEnd());
            }

            return resultado;
        }
    }
}
