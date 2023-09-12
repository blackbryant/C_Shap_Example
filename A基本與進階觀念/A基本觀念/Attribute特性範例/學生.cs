using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static A基本觀念.Attribute特性範例.ValidateExtension;

namespace A基本觀念.Attribute特性範例
{
    public class 學生
    {
        [LongValidate(100, 10000)]
        public long Money { set; get; }


    }
}
