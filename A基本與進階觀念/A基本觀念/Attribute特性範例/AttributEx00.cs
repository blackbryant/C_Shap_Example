using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * 1.Attribute特性:特性代碼會讓編譯器產生中間語言，將屬性產生IL在Metadata會有紀錄。
 *  參考CustomAttribute.cs 為建立一個Attribute檔案
 *   將檔案CustomAttribute.cs 加上 [AttributeUsage(AttributeTargets.All, AllowMultiple =true)]可以宣告重複修飾
 *  AttributeUsage: 修飾特性的源頭
 *  AttributeTargets: 為枚舉，用來限制止能修飾甚麼資料類型，Ex:AttributeTargets.Class 只能修飾類，複選則用 | 分開
 * 
 * 2. 常見特性有:    MVC Filter , ORM table key display
 * 3. 應用通常沒有再破壞封裝的狀況下，額外加信息與功能
 */
namespace A基本觀念.Attribute特性範例
{
    // [Custom]

    //[Custom()] 這是可以只是特性重複
    [Custom(10, Description = "特性使用")]
    public class AttributEx00
    {
        [Custom(10, Description = "ID特性使用")]
        public int Id { set; get; }

        [Obsolete("請不用在使用該方法，即將廢除",false)]
        public string WarnMessage(string message) 
        {
            Console.WriteLine($" WarnMessage {message}!");
            return "AA"; 
        }
        

        public string Anser(string message) 
        {
            return $"this is {message}";
        }

        public static void Main(string[] args) 
        {
            Console.WriteLine("==============");
           //用來訪談Attribute
           Type type = typeof(AttributEx00);
            if(type.IsDefined(typeof(CustomAttribute),true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine(attribute.Description); 
                attribute.Show();
            }

            PropertyInfo property = type.GetProperty("Id");
            if (property.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)property.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine(attribute.Description);
                attribute.Show();
            }

            MethodInfo method = type.GetMethod("WarnMessage"); 
            if (method.IsDefined(typeof(ObsoleteAttribute), true))
            {
                ObsoleteAttribute attribute = (ObsoleteAttribute)method.GetCustomAttribute(typeof(ObsoleteAttribute), true);
                Console.WriteLine(attribute.Message);
                ParameterInfo pInfo = method.GetParameters()[0];
                ParameterInfo returnInfo = method.ReturnParameter; 
                Console.WriteLine($"{pInfo.ParameterType} {pInfo.Name}");
                Console.WriteLine($"{returnInfo.ParameterType} {returnInfo.DefaultValue}");
            }


        }

    }
}
