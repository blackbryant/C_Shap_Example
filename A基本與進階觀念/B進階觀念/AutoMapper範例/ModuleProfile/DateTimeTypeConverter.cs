using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.AutoMapper範例.ModuleProfile
{
    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
          
            return DateTime.Today.ToString("yyyy/MM/dd");


        }
    }
}
