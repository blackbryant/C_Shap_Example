using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.泛型與集合
{
    public class GenericsEx01Console
    {


        public static void Main(string[] args) 
        {
            GenericsEx01<string> c01 = new GenericsEx01<string>();
            c01.GetGeneric("Hello");

            GenericsEx01<int> c02 = new GenericsEx01<int>();
            c02.GetGeneric(1234);

            GenericsEx01<DateTime> c03 = new GenericsEx01<DateTime>();
            c03.GetGeneric(DateTime.Now);

            GenericsEx01<decimal> c04 = new GenericsEx01<decimal>();
            c04.GetGeneric(1234.5M);

            GenericsEx01<float> c05 = new GenericsEx01<float>();
            c05.GetGeneric(0.11f);

            GenericsEx01<uint> c06 = new GenericsEx01<uint>();
            c06.GetGeneric(100);

            GenericsEx01<byte> c07= new GenericsEx01<byte>();
            c07.GetGeneric(100);

        }


    }
}
