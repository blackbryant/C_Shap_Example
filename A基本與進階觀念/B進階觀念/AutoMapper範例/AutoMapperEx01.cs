using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B進階觀念.AutoMapper範例.ModuleProfile;

namespace B進階觀念.AutoMapper範例
{
    public class AutoMapperEx01
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



            MapperConfiguration mc = new MapperConfiguration(mc => mc.AddProfile(new ModuleProfile.ModuleProfile()));
            IMapper mapper = mc.CreateMapper();
            DifferentPeople dpeople = mapper.Map<DifferentPeople>(p1);

            Console.WriteLine($"ID:{dpeople.PeopleId}, Name:{dpeople.PeopleName},Sex:{dpeople.PeopleSex}, Salary:{dpeople.PeopleSaralry}");

        }


    }
}
