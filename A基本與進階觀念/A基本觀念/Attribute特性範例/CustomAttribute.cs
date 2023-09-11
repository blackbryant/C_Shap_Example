using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace A基本觀念.Attribute特性範例
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple =true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute() { }

        public CustomAttribute(int id){}

        public string Description{ get;set; }

        public void Show() 
        {
            Console.WriteLine($" show something!"); 
        }



    }
}
