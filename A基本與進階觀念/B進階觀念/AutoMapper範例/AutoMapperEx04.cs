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

            //自定义类型转换器
            //1
            //MapperConfiguration mc2 = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            //    cfg.CreateMap<decimal, int>().ConvertUsing(new String2IntTypeConverter());
            //    cfg.CreateMap<int, string>().ConvertUsing(new Int2StringTypeConverter());
            //    cfg.CreateMap<Person, Account>();
            // } );
            MapperConfiguration mc2 = new MapperConfiguration(cfg => cfg.AddProfile(new ModuleProfile.ModuleProfile()) );
            mc2.AssertConfigurationIsValid();

            IMapper mapper1 = mc2.CreateMapper();
            Person p = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            Account account1 = mapper1.Map<Account>(p);
            System.Console.WriteLine($"Id:{account1.Id},Name:{account1.Name}, Saralry:{account1.Saralry},Sex:{account1.Sex},Birthday:{account1.Birthday}");

            //AutoMapperEx04.cs:自訂義解析器

            List<People> peoples = new List<People>();
            People p1 = new People() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            People p2 = new People() { Id = 002, Name = "Mary", Saralry = new decimal(2000.0), Birthday = new DateTime(2001, 8, 1), Sex = "F" };
            People p3 = new People() { Id = 003, Name = "Hill", Saralry = new decimal(1500.0), Birthday = new DateTime(2000, 5, 1), Sex = "M" };
            People p4 = new People() { Id = 004, Name = "Candy", Saralry = new decimal(1700.0), Birthday = new DateTime(1995, 6, 1), Sex = "F" };
            peoples.Add(p1);
            peoples.Add(p2);
            peoples.Add(p3);
            peoples.Add(p4);
            var result = mapper1.Map<List<People>, PeopleTotal>(peoples);
            System.Console.WriteLine($"Saralry:{result.SalaryTotal}");





        }


    }
}
