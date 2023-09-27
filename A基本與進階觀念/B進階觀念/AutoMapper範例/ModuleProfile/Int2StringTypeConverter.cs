using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.AutoMapper範例.ModuleProfile
{
    public class Int2StringTypeConverter : ITypeConverter<int, string>
    {
        public string Convert(int source, string destination, ResolutionContext context)
        {
            return source.ToString(); 
        }
    }
}
