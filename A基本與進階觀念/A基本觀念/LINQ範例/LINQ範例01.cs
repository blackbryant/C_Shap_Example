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

            IEnumerable<int> list1_2 = workItems.Select(item => item.Id); 



            //2.where 方法
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

            //3.Count方法
            var list2_2 = workItems.Count(x => x.Id >= 1 && x.Id <= 5);
            Console.WriteLine($"count:{list2_2}");
            //補充Any(): 至少有一筆滿足條件回傳true,沒有就返回false
            var list2_3 = workItems.Any(x => x.Id >= 1 && x.Id <= 5);



            //4.建立新的var類別
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

            //5.group by 
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


            //6. 常用的方法
            //(1) Single: 只有滿足返回值只有一筆
            //(2) SingleOrDefault:只有滿足返回值只有一筆，不滿足條件返回默認值
            //(3) First: 只返回第一筆資料
            //(4) FirstOrDefault:只有滿足條件返回第一筆資料，不滿足條件返回默認值
            ///以上方法都是針對IEnumerable接口，只要能返回IEnumerable就可以使用鏈式使用  
            


        }

    }

    //工作項目
    class WorkItem 
    {
        //工作編號
        public int Id { get; set; }
       
        //工作內容
        public string Desc { get; set; }
        //工作開始時間
        public DateTime StartTime { get; set; }
        //工作結束時間
        public DateTime EndTime { get; set; }
        //成本分類
        public string CostType { get; set; }

    }


  

}
