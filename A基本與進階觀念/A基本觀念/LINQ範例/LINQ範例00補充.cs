using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


/*
 * 由委託到LINQ標準 
 * 
 */ 
namespace A基本觀念.LINQ範例
{
    public class LINQ範例00補充
    {
       
        public static void Main(string[] args)
        {
            //Lamada表達式'
            int[] nums = new int[] { 1, 3, 5, 7, 9, 11, 13 };
            IEnumerable<int> list = MyWhere(nums, a=>a>10); 
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            //使用var宣告是讓編譯器自行推斷，來簡化宣告聲明
            var result01 = ()=> nums.Where(a=>a>10).ToList();


            //dynamic

        }


        //利用多線性的方法，符合條件就返回值，這樣的好處是處理的效率就更高
        static IEnumerable<int> MyWhere(IEnumerable<int> items, Func<int, bool> fun) 
        {
            foreach(int item in items) 
            {
                if (fun(item) == true) 
                {
                    Console.WriteLine("MyWhere:"+item);
                    yield return item;
                }
            }
        
        }

    }
     
}
