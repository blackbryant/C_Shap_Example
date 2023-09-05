using A基本觀念.LINQ範例;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.泛型與集合
{
    public  class GenericsEx01<T>
    {

        public void GetGeneric(T a) 
        {
            Console.WriteLine($"Name:{a?.GetType().Name},Value:{a}, FullName:{a.GetType().FullName}");
        }
     

    }
}
