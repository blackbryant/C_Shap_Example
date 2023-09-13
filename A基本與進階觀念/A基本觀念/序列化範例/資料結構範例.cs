using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.序列化範例
{
    public  class 資料結構範例
    {

        public static void Main(string[] args) 
        {
            List<Food> list = new List<Food>(); 
            list.Add(new Food("漢堡","好吃",100));
            list.Add(new Food("薯條", "好吃", 50));
            list.Add(new Food("熱狗", "好吃", 40));
            list.Add(new Food("可樂", "好吃", 20));
            list.Add(new Food("吐司", "好吃", 10));
            FoodIterator iterator = new FoodIterator(list);

            while (iterator.MoveNext()) 
            {
                Console.WriteLine($"{iterator.Current.Name}-${iterator.Current.Price}");
              
            }


        }

    }
}
