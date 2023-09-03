using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Lambda表達式
 * 有參數: {} => {方法}
 * 無參數: ()=>{方法}
 * 
 * 
 */
namespace A基本觀念
{
    public  class Lambda範例
    {
        IDictionary<int, string> _data;

        public Lambda範例(Func<IDictionary<int, string>> data)
        {
            _data = data();
        }


        
        public void Display() 
        {
            foreach (var k in _data) 
            {
                Console.WriteLine($"key:{k.Key}, value={k.Value}");
            }


        }


        public static void Main(string[] args)
        {
            Lambda範例 lambda = new Lambda範例( () => new Dictionary<int, string>
            {
                [1] = "aaa",
                [2] = "bbbb"

            });
          
           
        }


    }

}
