using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx04
    {

        public static void Main(string[] args)
        {
            //嵌套映射
            MapperConfiguration mc = new MapperConfiguration(cfg => cfg.AddProfile(new ModuleProfile.ModuleProfile()));
            IMapper mapper = mc.CreateMapper();
            var source = new Order()
            {     Total = 1000,
                   Customer = new Customer() { Name="統一"}
            };

          InnerOrder innerOrder =   mapper.Map<Order,InnerOrder>(source);
            System.Console.WriteLine($"{innerOrder.Customer.Name}");
            System.Console.WriteLine($"{innerOrder.Total}"); 



        }


    }
}
