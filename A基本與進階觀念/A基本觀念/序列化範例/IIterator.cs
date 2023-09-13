using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.序列化範例
{
    public interface IIterator<T>
    {
        T Current { get; }

        bool MoveNext();

        void Reset();

        public IIterator<T> GetEnumerator(); 
    }
}
