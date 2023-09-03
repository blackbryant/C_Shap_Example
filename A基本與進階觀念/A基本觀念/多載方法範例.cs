using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念
{
    public class 多載方法範例
    {

        //參數個數相同，但是資料類型不同
        public void Money(int x) { }
        public void Money(double x) { }

        public void Money(decimal x) { }

        //參數個數不同
        public int Amont(int x) { return x;  }
        public int Amont(int x, int y ) { return x+y; }

        public int Amont(int x, int y, int z) { return x+y+z; }


        //不同資料類型的回傳值無法組合多型


        public static void Main(string[] args) 
        {
            多載方法範例 c1 = new 多載方法範例(); 
            System.Console.WriteLine(c1.Amont(10));
            System.Console.WriteLine(c1.Amont(10,10));
            System.Console.WriteLine(c1.Amont(10,10,10));


        }



    }
}
