using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx03
    {

        public static void Main(string[] args) 
        {
            //反轉映射
            MapperConfiguration mc = new MapperConfiguration(cfg => cfg.AddProfile(new ModuleProfile.ModuleProfile()));
            IMapper mapper = mc.CreateMapper(); 

            var customer = new Customer() { Name = "Jack" };
            var order = new Order() { Customer = customer, Total = 15.8m };

            //Order -> OrderDTO 
            var orderDTO = mapper.Map<Order,OrderDTO>(order);
            orderDTO.CustomerName = "Joe";
             
            //OrderDTO -> Order 反向轉換
            var order2 = mapper.Map<OrderDTO,Order>(orderDTO);

            Console.WriteLine($"{order.Customer.Name}");
            Console.WriteLine($"{orderDTO.CustomerName}");
            Console.WriteLine($"{order2.Customer.Name}"); 


            //列表與數組




        }


    }
}
