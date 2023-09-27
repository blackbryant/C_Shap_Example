using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.AutoMapper範例.ModuleProfile
{
    public class String2IntTypeConverter : ITypeConverter<decimal, int>
    {
        public int Convert(decimal source, int destination, ResolutionContext context)
        {
            decimal temp = Math.Round(source, 1);
            int.TryParse(temp.ToString(),out  destination);
            return destination; 
        }
    }
}
