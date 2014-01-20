using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPattern.QueryObject;

namespace Stefanini.Apoio.AIC.Negocio.Interface
{
    public interface IScriptSQL<T>
    {
        SqlInsert GeraScriptInsert(T obj);        
    }
}
