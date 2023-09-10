using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


/*
 *  擴充方法
 *  1. 可以不需要修改類別，就可以延升方法
 *  2. 缺點:有相同方法名稱時，只會優先調用實例方法，要注意使用時機 
 *  3. 缺點:讓所有類型都會這樣擴展的方法，最好指定類型擴展
 *  
 *  實作: 最好限制
 * Fnnc(this LINQ範例_Student student)
 * Fnnc(this Object  student)
 * Fnnc( this int student)
 */
namespace A基本觀念.LINQ範例
{
    public static class LINQ範例02_類別擴充方法
    {
        public static void SaySelfName(this LINQ範例_Student student)
        {
            Console.WriteLine($"My Name is {student.Name}");

        }

        // 擴充Lambda方法，應用各種資料類型
        public static List<T> GetFuncList<T>(this List<T> list, Func<T, bool> func) 
        {
            var result = new List<T>();
            foreach(T item in list) 
            {
                if (func.Invoke(item)) 
                {
                    result.Add(item);   
                }
            }
            return result;
        }

        //擴充方法使用迭代功能IEnumerable<T>，實作Linq寫法
        public static IEnumerable<T> GetIeFuncList<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            if (list == null) 
            {
               throw new Exception("list is null");
            }
            if (func == null)
            {
                throw new Exception("list is null");
            }

            foreach (T item in list)
            {
                Console.WriteLine($"{item} {func}");
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
           
        }


        public static void Main(string[] args)
        {
            LINQ範例_Student studnet = new LINQ範例_Student();
            studnet.Id = 1;
            studnet.Name = "王大豐";
            studnet.Age = 30;
            studnet.ClassId = "002";
            studnet.SaySelfName();
            LINQ範例_Student studnet2 = new LINQ範例_Student();
            studnet2.Id = 2;
            studnet2.Name = "成大天";
            studnet2.Age = 30;
            studnet2.ClassId = "001";
            LINQ範例_Student studnet3 = new LINQ範例_Student();
            studnet3.Id = 3;
            studnet3.Name = "林大同";
            studnet3.Age = 20;
            studnet3.ClassId = "003";
            List<LINQ範例_Student> studnets = new List<LINQ範例_Student> { studnet, studnet2, studnet3 };

            //將List解偶回傳符合的資料
            List<LINQ範例_Student> querStudent01 =  studnets.GetFuncList<LINQ範例_Student>(x => x.Id == 1);
            Console.WriteLine($"{querStudent01.Count}");

            //使用迭代  
            IEnumerable< LINQ範例_Student> querStudent02 = studnets.GetIeFuncList<LINQ範例_Student>(x => x.Id == 1);
            Console.WriteLine($"{querStudent02.Count()}");

            // Where : 完成條件過濾
            // Select :  數據集合轉換，可以搭配var建立匿名型別
            // Min/ Max/ OrderBy
            //
            IEnumerable<int> querStudent03 = studnets.Where(x =>
            {
                return x.Age > 10;
            }).Select<LINQ範例_Student, int>(x => x.Name.Length); 
            Console.WriteLine($"姓名的長度:{querStudent03}");

           var querStudent04 = studnets.Where(x =>
            {
                return x.Age > 10;
            }).Select(x => new { Id= x.Id, Name=x.Name });
            foreach (var item in querStudent04) 
            {
                Console.WriteLine($"Name:{item.Name}");
            }


        }

    }

}
