using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;
using System.Dynamic;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx06
    {

        public static void Main(string[] args)
        {
            //AutoMapperEx06:條件映射:當條件符合才做映射
            Person p1 = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            Person p2 = new Person() { Id = 002, Name = "Hob", Saralry = new decimal(1000.0), Birthday = new DateTime(1994, 9, 2), Sex = "S" };
            MapperConfiguration mc = new MapperConfiguration(cfg => cfg.AddProfile(new ModuleProfile.ModuleProfile()) );
            
            IMapper mapper = mc.CreateMapper();

            People people1 = mapper.Map<People>(p1);
            People people2 = mapper.Map<People>(p2);
            System.Console.WriteLine($"Id:{people1.Id},Name:{people1.Name}, Sex:{people1.Sex}" );
            System.Console.WriteLine($"Id:{people2.Id},Name:{people2.Name}, Sex:{people2.Sex}");  //出現空值

            //Dynamic和expandoobject映射
            dynamic dyPerson = new ExpandoObject();
            dyPerson.Id = 0010; 
            dyPerson.Name = "漢堡";
            dyPerson.Saralry = 100.0;
            dyPerson.Birthday = new DateTime(1993, 10, 1);
            dyPerson.Sex = "M";

            System.Console.WriteLine("動態物件ExpandoObject ->Person ");
            Person person01 = mapper.Map<Person>(dyPerson);
            System.Console.WriteLine($"Id:{person01.Id},Name:{person01.Name}, Sex:{person01.Sex}");
            System.Console.WriteLine("動態物件ExpandoObject -> new ExpandoObject ");
            dynamic dyPerson2 = mapper.Map<ExpandoObject>(dyPerson);
            System.Console.WriteLine($"Id:{dyPerson2.Id},Name:{dyPerson2.Name}, Sex:{dyPerson2.Sex}");


            //泛型轉換
            System.Console.WriteLine("泛型轉換");
            var source = new TSource<int> { Value = 100 };
            var dest = mapper.Map<TTarget<int>>(source);
            System.Console.WriteLine($"value:{dest.Value}");











        }


    }
}
