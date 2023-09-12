using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace A基本觀念.Attribute特性範例
{
    //利用方法延伸來封裝
    public static class ValidateExtension
    {
        public static bool Validate(this object obj)
        {
            Type type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(LongValidateAttribute), true))
                {
                    object[] attributeArray = prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true);
                    foreach (AbstractValidateAttribute attribute in attributeArray)
                    {
                        if (!attribute.Validate(prop.GetValue(obj)))
                        {
                            return false;
                        }

                    }

                }
            }
            return true;
        }

    }

    [AttributeUsage(AttributeTargets.Property| AttributeTargets.Field)]
    public class LongValidateAttribute : AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;

        public LongValidateAttribute(long min, long max)
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
                    {
                        if (lResult > _Min && lResult < _Max)
                        {
                            return true;

                        }
                    }
                }
            }
            return false;

        }
    }
}
