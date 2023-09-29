using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx05
    {

        public static void Main(string[] args)
        {
            //AutoMapperEx05:投影
            Person p = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            MapperConfiguration mc = new MapperConfiguration(cfg => cfg.AddProfile(new ModuleProfile.ModuleProfile()) );
            mc.AssertConfigurationIsValid();
            IMapper mapper = mc.CreateMapper();
            PersonForm pf = mapper.Map<PersonForm>(p);

            System.Console.WriteLine($"Id:{pf.Id},Name:{pf.Name}, Saralry:{pf.Saralry},Sex:{pf.Sex},Year:{pf.Year} , Month:{pf.Month}, day:{pf.Day}");


            //AutoMapperEx05.cs : 空值替換成字串
            MapperConfiguration mc2 = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>().ForMember(a => a.Name, src => src.NullSubstitute("unknown")));
            IMapper mapper2 = mc2.CreateMapper(); ;
            Person p2 = new Person() { Id = 001, Name = null, Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            People people2 = mapper2.Map<People>(p2);

            System.Console.WriteLine($"Name:{people2.Name}");


            //匹配執行之前和之後
            // 前綴 -> Mapper -> 後綴
            MapperConfiguration mc3 = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>().BeforeMap((src,dest) => src.Name = "前綴_"+ src.Name)
                                                                                                                                                                       .AfterMap((src, dest) => dest.Name = dest.Name+"_後綴"));
            IMapper mapper3 = mc3.CreateMapper(); ;
            Person p3= new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            People people3 = mapper3.Map<People>(p3);

            System.Console.WriteLine($"Name:{people3.Name}");
        }


    }
}
