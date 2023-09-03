using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念
{
    public class 匿名方法與委派
    {
        /// <summary>
        /// 新增委派
        /// </summary>
        /// <param name="action"></param>
        /// <param name="thing"></param>
        /// <returns></returns>
        private delegate string DoSomething(string action, string thing);

        public static void Main(string[] args)
        {
            ///使用匿名方法來實作方法，但是匿名方法無法給其他程式使用
            DoSomething d01 = delegate (string action, string thing)
            {
                return action + ":" + thing;
            };
            System.Console.WriteLine(d01("吃","炒飯"));
            System.Console.WriteLine(d01("開", "飛機"));
            System.Console.WriteLine(d01("跳", "繩子"));
            System.Console.WriteLine(d01("沒", "車子"));

        }

    }
}
