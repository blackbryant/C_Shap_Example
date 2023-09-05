using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//定義一個泛型介面
namespace A基本觀念.泛型與集合
{
     interface IGenericsEx02<T,V>
    {
        void Output(T a, V b);

    }
}
