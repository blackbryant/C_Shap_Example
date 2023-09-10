using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 實作一個
 */
namespace A基本觀念
{
    public class 委派總結範例
    {
        // 1. 定義委託
        private  delegate  bool DelegateThen(Item item); 
        //2.1 完成方法:超過1000才顯示
        private static bool GreaterThan1000(Item item) 
        {
            return item.Price > 1000; 
        }
        //2.2 完成方法:低於500才顯示
        private static bool LessThan500(Item item)
        {
            return item.Price > 500;
        }


        //3. 將邏輯方法用委託方式抽象化
        private static List<Item> GetListDelegate(List<Item> list, DelegateThen method) 
        {
            List<Item> result = new List<Item>();  

            foreach (Item item in list) {
                if (method.Invoke(item)) 
                {
                    result.Add(item);
                }
            }
            return result;
        
        }

        public static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item(001, "電腦", 3000),
                new Item(002, "三明治", 100),
                new Item(003, "披薩", 200),
                new Item(004, "手機", 1000),
                new Item(005, "書籍", 500),
                new Item(006, "飲料", 10),
                new Item(007, "珠寶", 20000),
                new Item(008, "衣服", 600),
                new Item(009, "鑽石", 71000),
                new Item(010, "電動按摩器", 24000)
            };
            //單一委派
            DelegateThen thanA = new DelegateThen(GreaterThan1000);
            List<Item> result =  GetListDelegate(items, thanA);
            Console.WriteLine($"數量:{result.Count}");


            //多個委派串接
            DelegateThen thanMore = new DelegateThen(GreaterThan1000);
            thanMore += new DelegateThen(LessThan500);
            List<Item> thanMoreResult = GetListDelegate(items, thanMore);

            Console.WriteLine($"數量:{thanMoreResult.Count}");



        }

         class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }

            public Item(int Id, string Name, int Price)
            {
                this.Id = Id;
                this.Name = Name;
                this.Price = Price;

            }

        }

    }

   


}
