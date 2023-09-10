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
    public class LINQ範例00
    {
        private delegate void ShowDelegate(string name);

        public  void SayHelloWorld(string name) 
        {
            Console.WriteLine($"Hellow World {name} "); 
        }

        public static void Main(string[] args)
        {
            //Net 1.0
            LINQ範例00 ex = new LINQ範例00(); 
            ShowDelegate say01 = new ShowDelegate(ex.SayHelloWorld);
            say01.Invoke("Jack");

            //Net 2.0
            ShowDelegate say02 = new ShowDelegate(
                delegate (string name) 
                {
                    Console.WriteLine($"Hellow World {name} ");
                });

            //Net 3.0
            ShowDelegate say03 = new ShowDelegate(
                (string name) =>
               {
                   Console.WriteLine($"Hellow World {name} ");
               });

            ShowDelegate say04 =   (string name) => Console.WriteLine($"Hellow World {name} ");

            //Action 框架提供16個參數，沒有返回值、 泛型委託
            Action act01 = () => Console.WriteLine($"Hellow World  ");

            //Func
            Func<int> func01 = () => DateTime.Now.Day;

        }

    }
     
}
