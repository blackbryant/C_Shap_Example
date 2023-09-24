using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace A基本觀念.LINQ範例.表達式
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple =true)]
    public class MapperAttribute : Attribute
    {
        public MapperAttribute() { }

         
        public string Name{ get;set; }

        public string Order { get;set; }



    }
}
