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





        }


    }
}
