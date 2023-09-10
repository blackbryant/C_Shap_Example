using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *  LINQ to Object  內存的數據
 *  LINQ to Sql 
 *  LINQ to xml 
 *  LINQ to Excel 
 *  LINQ to Nosql 
 *  LINQ to Memcached
 *  LINQ to Redis
 *  
 */ 
namespace A基本觀念.LINQ範例
{
    public class LINQ範例01
    {


        public static void Main(string[] args)
        {
            List<WorkItem> workItems = new List<WorkItem>();
            workItems.Add(new WorkItem { Id = 1, Desc="製程A",StartTime=new DateTime(2019,1,1,9,0,0),EndTime=new DateTime(2020,1,1,9,0,0)});
            workItems.Add(new WorkItem { Id = 2, Desc = "製程B", StartTime = new DateTime(2019, 5, 1, 9, 0, 0), EndTime = new DateTime(2020, 6, 1, 9, 0, 0) });
            workItems.Add(new WorkItem { Id = 3, Desc = "製程C", StartTime = new DateTime(2019, 6, 1, 9, 0, 0), EndTime = new DateTime(2020, 7, 1, 9, 0, 0) });
            workItems.Add(new WorkItem { Id = 3, Desc = "製程D", StartTime = new DateTime(2019, 7, 1, 9, 0, 0), EndTime = new DateTime(2020, 8, 1, 9, 0, 0) });
            workItems.Add(new WorkItem { Id = 3, Desc = "製程E", StartTime = new DateTime(2019, 9, 1, 9, 0, 0), EndTime = new DateTime(2020, 10, 1, 9, 0, 0) });

            //求出最大加工時間
            var max = workItems.Max(w=>w.EndTime-w.StartTime);
            Console.WriteLine("最常加工時間:{0:%d}天,{0:%h}時,{0:%m}分,{0:%s}秒",max);

            //字串處理
            string[] str_arr = { "abc", "def" ,"ghij","loklod"};
            int len = str_arr.Sum(x=> x.Length);
            Console.WriteLine($"string length:{len}");

            //合併兩個串列
            List<string> list01 = new List<string> { "a","b","c"};
            List<string> list02 = new List<string> { "k", "d", "g" };
            var result = list01.Concat<string>(list02);
            Console.WriteLine("Join 字串:"+string.Join("、",result));

            //找出消費大於1000的
            SpendMoney[] spendMoneys =
            {
                new SpendMoney(1,10,10),
                new SpendMoney(2,20,20),
                new SpendMoney(3,30,30),
                new SpendMoney(4,40,40),
                new SpendMoney(5,50,60),
                new SpendMoney(7,60,10)
            };
            int count = spendMoneys.Count(x => (x.Money * x.Amount) > 1000);
            Console.WriteLine($"超過1000數目有:{count}");

        }

    }

    class WorkItem 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }

    class SpendMoney
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Money { get; set; }

        public SpendMoney(int id, int amount, int money)
        {
            Id = id;
            Amount = amount;
            Money = money;
        }   
    }
  

}
