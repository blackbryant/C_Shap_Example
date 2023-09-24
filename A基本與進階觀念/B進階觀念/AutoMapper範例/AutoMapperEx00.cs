using AutoMapper;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using B進階觀念.AutoMapper範例;
using B進階觀念.AutoMapper範例.ModuleProfile;

public class AutoMapperEx00
{
    private static void Main(string[] args)
    {
        List<Person> persons = new List<Person>(); 
        Person p1 = new Person() { Id = 001, Name = "Jack", Saralry = new decimal(1000.0), Birthday = new DateTime(1993, 10, 1), Sex = "M" };
        Person p2 = new Person() { Id = 002, Name = "Mary", Saralry = new decimal(2000.0), Birthday = new DateTime(2001, 8, 1), Sex = "F" };
        Person p3 = new Person() { Id = 003, Name = "Hill", Saralry = new decimal(1500.0), Birthday = new DateTime(2000, 5, 1), Sex ="M"  };
        Person p4 = new Person() { Id = 004, Name = "Candy", Saralry = new decimal(1700.0), Birthday = new DateTime(1995, 6, 1), Sex = "F" };
        persons.Add(p1);
        persons.Add(p2);
        persons.Add(p3);
        persons.Add(p4);

        //將Person值Map到->People
        //Mapper設定初始化
        MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.CreateMap<Person, People>() );
        IMapper mapper = configuration.CreateMapper();
        //  單筆Person -> People
        People b1 = mapper.Map<People>(p1);
        Console.WriteLine($"單筆People");
        Console.WriteLine($"ID:{b1.Id}, Name:{b1.Name}") ;

        //多筆Person值映射到People
        //使用MapperConfiguration設定map規則
        List<People> peoples = mapper.Map<List<People>>(persons);
        Console.WriteLine($"多筆People");
        foreach (People p in peoples) 
        {
            Console.WriteLine($"ID:{p.Id}, Name:{p.Name},Sex:{ p.Sex}");
        }

        //用於多個映射物件配置
        List<Item> items = new List<Item>(); 
        Item i1 = new Item() { Id = 001, Money = 3000, Name = "CellPhone" };
        Item i2 = new Item() { Id = 002, Money = 1000, Name = "Fan" };
        Item i3 = new Item() { Id = 003, Money = 2000, Name = "Monitor" };
        Item i4 = new Item() { Id = 004, Money = 5000, Name = "Computer" };
        items.Add(i1);
        items.Add(i2);
        items.Add(i3);
        items.Add(i4);

        MapperConfiguration configuration2 = new MapperConfiguration(cfg =>
        {   cfg.CreateMap<Person, People>();
            cfg.CreateMap<Item, Product>();
        });
        IMapper mapper2 = configuration2.CreateMapper();
        List<People> peoples2 = mapper2.Map<List<People>>(persons);
        List<Product> products2 = mapper2.Map <List<Product>>(items); 

        Console.WriteLine($"多個物件Map匹配設定");
        foreach (People p in peoples)
        {
            Console.WriteLine($"ID:{p.Id}, Name:{p.Name},Sex:{p.Sex}");
        }

        foreach (Item i in items)
        {
            Console.WriteLine($"ID:{i.Id}, Name:{i.Name},Money:{i.Money}");
        }

        //使用Profile來建立Mapping 規則
       MapperConfiguration profileConfiguration = new MapperConfiguration(cfg=> cfg.AddProfile(new ModuleProfile()));
        IMapper mapper3 = profileConfiguration.CreateMapper();
        List<People> peoples3 = mapper3.Map<List<People>>(persons);
        Console.WriteLine($"使用Profile來建立Mapping 規則");
        foreach (People p in peoples3)
        {
            Console.WriteLine($"ID:{p.Id}, Name:{p.Name},Sex:{p.Sex}");
        }




    }
}