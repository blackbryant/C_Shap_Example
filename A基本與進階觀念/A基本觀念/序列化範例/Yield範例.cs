using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 使用Yield取得資料，會是一筆筆取出
 * 
 */
namespace A基本觀念.序列化範例
{
    public class Yield範例
    {
        //
        public IEnumerable<Food> GetYieldFunction(List<Food> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Thread.Sleep(2000);
                yield return list[i];
            }
        }

        public IEnumerable<Food> GetAllFunction(List<Food> list)
        {
            List<Food> resultList = new List<Food>();
            for (int i = 0; i < list.Count; i++)
            {
                resultList.Add(list[i]);
            }
            return resultList;
        }


        public static void Main(string[] args)
        {
            List<Food> list = new List<Food>();
            list.Add(new Food("電腦", "", 3000));
            list.Add(new Food("耳機", "", 1000));
            list.Add(new Food("喇叭", "", 400));
            list.Add(new Food("螢幕", "", 10000));
            list.Add(new Food("手機", "", 50000));
            list.Add(new Food("滑鼠", "", 999));

            Yield範例 範例 = new Yield範例();


            IEnumerable<Food> it = 範例.GetYieldFunction(list);
            foreach (Food food in it)
            {
                System.Console.WriteLine($"{food.Name}");
            }
            IEnumerable<Food> it2 = 範例.GetAllFunction(list); 
            foreach (Food food in it2)
            {
                System.Console.WriteLine($"{food.Name}");
            }
          

        }


    }
}
