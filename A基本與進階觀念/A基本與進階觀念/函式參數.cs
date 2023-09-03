using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本與進階觀念
{
    public class 函式參數
    {

        public string Name { set; get; }
        public string Description { set; get; } 
        public string Type { set; get; }

       

        public void UpdateValue(函式參數 f) 
        {
            f = new 函式參數()
            {
               Name="更新名字",
               Description="更新說明",
               Type="更新類型"
            };
        
        }

        public void UpdateRef(ref 函式參數 f)
        {
            f = new 函式參數()
            {
                Name = "更新名字",
                Description = "更新說明",
                Type = "更新類型"
            };

        }


        public void CalculateValue(int x, int y ,out int result ) 
        {

            result = x + y; 
        }

        public static void Main(string[] args) 
        {
            函式參數 c1 = new 函式參數();
            c1.Name = "王孝明";
            c1.Description = "高雄人22歲";
            c1.Type = "無";

            //Ref 參數與沒有參數的範例
            c1.UpdateValue(c1);
            Console.WriteLine($"使用一般函式，名稱{c1.Name},說明:{c1.Description}, Type:{c1.Type}");
            c1.UpdateRef(ref c1);
            Console.WriteLine($"使用REF函式，名稱{c1.Name},說明:{c1.Description}, Type:{c1.Type}");
            int valuea = 0;
            c1.CalculateValue(10, 20, out valuea);
            Console.WriteLine(valuea);

        }




    }
}
