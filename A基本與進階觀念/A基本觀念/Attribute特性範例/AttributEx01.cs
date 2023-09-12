using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.Attribute特性範例
{
    public class AttributEx01
    {

        public static void Main(string[] args)
        {
            學生 student = new 學生();
            student.Money = 100000;
            if (student.Validate() == false) 
            {
                Console.WriteLine("發生錯誤");
            }

        }
    }




}
