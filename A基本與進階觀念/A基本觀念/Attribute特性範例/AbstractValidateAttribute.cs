using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.Attribute特性範例
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object obj);

    }
}
