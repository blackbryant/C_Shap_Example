using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Linq to Object(Enumeranble): 
 * 
 * Linq to Sql(Queryable): SQL+ADO.NET
 * 
 * Linq to XML: 封裝XML操作
 * 
 */
namespace A基本觀念.LINQ範例
{
    public class LINQ範例01
    {


        public static void Main(string[] args)
        {
            List<WorkItem> workItems = new List<WorkItem>();
            workItems.Add(new WorkItem { Id = 1, Desc = "製程A", StartTime = new DateTime(2019, 1, 1, 9, 0, 0), EndTime= new DateTime(2020, 1, 1, 9, 0, 0), CostType="成本A"});
            workItems.Add(new WorkItem { Id = 2, Desc = "製程B", StartTime = new DateTime(2019, 5, 1, 9, 0, 0), EndTime = new DateTime(2020, 8, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 3, Desc = "製程C", StartTime = new DateTime(2020, 8, 1, 10, 0, 0), EndTime = new DateTime(2020, 11, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 4, Desc = "製程D", StartTime = new DateTime(2021, 11, 1, 10, 0, 0), EndTime = new DateTime(2021, 2, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 5, Desc = "製程E", StartTime = new DateTime(2021, 2, 1, 10, 0, 0), EndTime = new DateTime(2021, 5, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 6, Desc = "製程F", StartTime = new DateTime(2021, 8, 1, 9, 0, 0), EndTime = new DateTime(2021, 8, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 7, Desc = "製程G", StartTime = new DateTime(2022, 11, 1, 9, 0, 0), EndTime = new DateTime(2022, 11, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 8, Desc = "製程H", StartTime = new DateTime(2023, 2, 1, 9, 0, 0), EndTime = new DateTime(2023, 2, 1, 9, 0, 0), CostType = "成本A" });
            workItems.Add(new WorkItem { Id = 9, Desc = "製程I", StartTime = new DateTime(2023, 8, 1, 9, 0, 0), EndTime = new DateTime(2023, 5, 1, 9, 0, 0), CostType = "成本A" });
        
            //求出加工時間
            var max = workItems.Max(w=>w.EndTime-w.StartTime);
            Console.WriteLine("最常加工時間:{0:%d}天,{0:%h}時,{0:%m}分,{0:%s}秒",max);

            /////Linq to Object(Enumeranble): 

            //1. 一般寫法
            var list = from item in workItems
                       where  item.Id ==1
                       select item;
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Desc}"); 
            }

            //2.
            var list2 = workItems.Where<WorkItem>(x => x.Id >= 1 && x.Id <= 5)
                        .Select(s => new
                        {
                            Id = s.Id,
                            Name = s.Desc,
                            CreateTime = s.StartTime,
                            EndTime = s.EndTime
                        })
                        .OrderBy(s => s.Id)
                        .OrderByDescending(s => s.EndTime)
                        .Skip(1) //跳過幾條
                        .Take(3); //取幾條
                        
            foreach (var item in list2)
            {
                Console.WriteLine($"{item.Name}");
            }

            //3.建立新的var類別
            var list3 = workItems.Where<WorkItem>(x => x.Id >= 1 && x.Id <= 5)
                      .Select(s => new
                      {
                          Id = s.Id,
                          Name = s.Desc,
                          CreateTime = s.StartTime,
                          EndTime = s.EndTime,
                          ClassId = s.Desc.Contains("製程") ? "A" : "B"
                      }) ;
                      

            foreach (var item in list3)
            {
                Console.WriteLine($"{item.Name}");
            }

            //4.group by 
            var list4 = from item in workItems
                        where item.Id > 4
                        group item by item.CostType into sg
                        select new
                        {
                           id = sg.Key,
                           maxEnd = sg.Max(x => x.EndTime)


                        };
            foreach (var item in list4)
            {
                Console.WriteLine($"{item.id}-{item.maxEnd}");
            }



        }

    }

    class WorkItem 
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CostType { get; set; }

    }


  

}
