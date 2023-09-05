using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.泛型與集合
{
    public class GeneriocsEx02B<T, V> : IGenericsEx02<T, V>
    {
        public void Output(T a, V b)
        {
            Console.WriteLine($"name:{a} , value:{b}");
        }
    }
}
