using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * 
 * 
 * 

 * 
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

            //求出加工時間
            var max = workItems.Max(w=>w.EndTime-w.StartTime);
            Console.WriteLine("最常加工時間:{0:%d}天,{0:%h}時,{0:%m}分,{0:%s}秒",max);


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


  

}
