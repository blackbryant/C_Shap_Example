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
            //需要兩邊的資料型態可以匹配
            List<Person> persons = new List<Person>();
            Person p1 = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            Person p2 = new Person() { Id = 002, Name = "Mary", Saralry = new decimal(2000.0), Birthday = new DateTime(2001, 8, 1), Sex = "F" };
            Person p3 = new Person() { Id = 003, Name = "Hill", Saralry = new decimal(1500.0), Birthday = new DateTime(2000, 5, 1), Sex = "M" };
            Person p4 = new Person() { Id = 004, Name = "Candy", Saralry = new decimal(1700.0), Birthday = new DateTime(1995, 6, 1), Sex = "F" };
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
            persons.Add(p4);


            IEnumerable<People> people01 = mapper.Map<List<Person>, IEnumerable<People>>(persons);
            ICollection<People> people02 = mapper.Map<List<Person>, ICollection<People>>(persons);
            List<People> people03 = mapper.Map<List<Person>, List<People> >(persons);
            People[] people04 = mapper.Map<Person[], People[]>(persons.ToArray());

            //特例:如果當我為null時候，mapping後不會變成null，只是數量為空
            List<Person> emptyPersons = null;
            IEnumerable<People> emptyPeople01 = mapper.Map<List<Person>, IEnumerable<People>>(emptyPersons);
            Console.WriteLine($"{emptyPeople01.Count()}");

            //當有繼承時處理
            Person pA = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            Person pB = new Person() { Id = 002, Name = "Holl", Saralry = new decimal(1040.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
            ChildPerson cpC = new ChildPerson() { Id = 002, Name = "Holl", Saralry = new decimal(1040.0), Birthday = new DateTime(1993, 10, 1), Sex = "M", Job = "Engineer" };

            var sources = new[] { pA,pB,cpC };
            mapper.Map<Person[], People[]>(sources);

        }


    }
}
