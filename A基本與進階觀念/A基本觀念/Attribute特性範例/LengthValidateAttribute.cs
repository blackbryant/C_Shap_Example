using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.Attribute特性範例
{


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LengthValidateAttribute : AbstractValidateAttribute
    {
        private long _Min = 0; 
        private long _Max = 0;

        public LengthValidateAttribute(long min, long max) 
        {
            this._Min = min;
            this._Max = max;    
        }


        public override bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (long.TryParse(value.ToString(), out long lResult))
                {
                    int length = lResult.ToString().Length; 
                    if (length > _Min && length < _Max)
                    {
                        return true;

                    }
                    
                }
            }
            return false;
            
        }


    }
}
