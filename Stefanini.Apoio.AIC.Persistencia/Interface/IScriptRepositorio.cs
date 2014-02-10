using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Stefanini.Apoio.AIC.Persistencia
{
    public interface IScriptRepositorio
    {
        IDictionary<string, string> Run(FileInfo[] files);
    }
}
