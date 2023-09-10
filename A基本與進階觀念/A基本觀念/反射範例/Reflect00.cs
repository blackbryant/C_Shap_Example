using System;
using System.Reflection;

/*
 * 反射：System.Reflection 就是NET框架來幫助類別庫，使用metadata方式來建立實例
 * 
 * 
 * 
 */
namespace A基本觀念.反射範例
{
    public class Reflect00
    {
        public Reflect00()
        {
        }


        public static void Main(string[] args)
        {
            // Load(): dll檔案目錄，當前執行檔的目錄載入
            Assembly assembly1 =  Assembly.Load("A基本觀念");

            //LoadFile():完整dll檔案路徑
            // Assembly assembly2 = Assembly.LoadFile("/Users/bryantlin/Documents/C_Shap_Example/A基本與進階觀念/A基本觀念/bin/Debug/net6.0/A基本觀念.dll");

            //LoadFrom()
            // Assembly assembly3 = Assembly.LoadFrom("A基本觀念.dll");

            foreach (var meta in assembly1.GetModules())
            {
                Console.WriteLine($"Name:{meta.FullyQualifiedName}");
                

            }

            foreach (var meta in assembly1.GetTypes())
            {
                Console.WriteLine($"Type:{meta.FullName}");

            }
            //2.取得類訊息
            Type type = assembly1.GetType("A基本觀念.反射範例.ReflectExample");
            //3.建立實例
            object obj = Activator.CreateInstance(type);
            //4.類型轉換
            ReflectExample reflectExample = (ReflectExample)obj;
            //5.呼叫方法
            reflectExample.SayHello();


        }


    }
}

