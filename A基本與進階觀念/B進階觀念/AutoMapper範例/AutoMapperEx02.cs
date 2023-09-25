using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx02
    {

        public static void Main(string[] args) 
        {
            List<Person> persons = new List<Person>();
            Person p1 = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            Person p2 = new Person() { Id = 002, Name = "Mary", Saralry = new decimal(2000.0), Birthday = new DateTime(2001, 8, 1), Sex = "F" };
            Person p3 = new Person() { Id = 003, Name = "Hill", Saralry = new decimal(1500.0), Birthday = new DateTime(2000, 5, 1), Sex = "M" };
            Person p4 = new Person() { Id = 004, Name = "Candy", Saralry = new decimal(1700.0), Birthday = new DateTime(1995, 6, 1), Sex = "F" };
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
            persons.Add(p4);


            // 差異Mappging， 對象屬性不一定互相可以匹配
            MapperConfiguration mc = new MapperConfiguration(mc => mc.AddProfile(new ModuleProfile.ModuleProfile()));
            IMapper mapper = mc.CreateMapper();
            
            DifferentPeople dpeople = mapper.Map<DifferentPeople>(p1);
          
            Console.WriteLine($"ID:{dpeople.PeopleId}, Name:{dpeople.PeopleName},Sex:{dpeople.PeopleSex}, Salary:{dpeople.PeopleSaralry}");


            // 驗證:加入驗證只要有兩邊一個不符合就會拋出throw Exception
            try
            {
                DifferentPeople dpeople2 = mapper.Map<DifferentPeople>(p1);
                //開啟驗證
                //mapper.ConfigurationProvider.AssertConfigurationIsValid();
                Console.WriteLine($"ID:{dpeople.PeopleId}, Name:{dpeople.PeopleName},Sex:{dpeople.PeopleSex}, Salary:{dpeople.PeopleSaralry}");
            }
            catch(Exception ex) {
                System.Console.WriteLine(ex.StackTrace);
                System.Console.WriteLine(ex.ToString());
            }

            //忽略不檢查 Ignore

            //忽略不驗證兩邊物件屬性的字串是否相同
            MapperConfiguration mc02 = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>(MemberList.None));
            IMapper mapper02 = mc02.CreateMapper();

            //檢查目標物件所有性是否有匹配
            MapperConfiguration mc03 = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>(MemberList.Destination));
            IMapper mapper03 = mc03.CreateMapper();

            //檢查源頭物件所有性是否有匹配
            MapperConfiguration mc04 = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>(MemberList.Source));
            IMapper mapper04 = mc04.CreateMapper();


        }


    }
}
