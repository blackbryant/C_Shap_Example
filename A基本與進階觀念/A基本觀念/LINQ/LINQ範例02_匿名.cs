using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *  
 */ 
namespace A基本觀念.LINQ範例
{
    public class LINQ範例02_匿名
    {


        public static void Main(string[] args)
        {
            //用Obj
            Object Student_obj = new { Id = 2, Name = "林大豐", Age = 15, ClassId = "002" };
            //無法編譯通過
           // Console.WriteLine($"Id:{Student_obj.Id}, {Student_obj.Name}");


            //匿名用 var 語法糖
            // 中間語言:<>f__Any*** =>編譯器會將var自動類別長出getId、getName等等方法
            var Student_var = new { Id = 2, Name = "林大豐", Age = 15, ClassId = "002" };
            Console.WriteLine($"Id:{Student_var.Id}, {Student_var.Name}");

            //var限制
            //var a;   #編譯器無法通過，因為var的資料型態是編譯器自動推算，沒有初始值就無法自動推算 



            //匿名用 var
            dynamic Student_dynamic = new { Id = 2, Name = "林大豐", Age = 15, ClassId = "002" };
            Console.WriteLine($"Id:{Student_dynamic.Id}, {Student_dynamic.Name}");




        }

    }
     
  

}
