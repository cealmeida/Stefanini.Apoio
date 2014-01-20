using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.QueryObject
{
    public class ObjectPropertyInterator
    {

        private Object obj;
        private Type t;
        private int idiceDaPropriedade = -1;

        public ObjectPropertyInterator(Object obj)
        {
            this.obj = obj;
            this.t = obj.GetType();
        }        

        public bool HasRow
        {
            get
            {
                return this.idiceDaPropriedade < (t.GetProperties().Length - 1);
            }
        }


        public KeyValuePair<string, object> NextRow()
        {
            this.idiceDaPropriedade++;
          
            return new KeyValuePair<string, object>(
                                                    this.t.GetProperties()[this.idiceDaPropriedade].Name,
                                                    this.t.GetProperties()[this.idiceDaPropriedade].GetValue(this.obj, null)); 
        }

        
    }
}
