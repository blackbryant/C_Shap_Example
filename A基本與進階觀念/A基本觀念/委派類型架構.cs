using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/**
 * Action: 處理void的方法類型
 * Func: 處理有回傳值的方法類型
 * 
 */
namespace A基本觀念
{
    public class 委派類型架構
    {

        /// <summary>
        /// action 範例 1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        private void ShowMessage(string name, int age)
        {
            Console.WriteLine($"姓名:{name}, 年紀:{age}");
        }

        /// <summary>
        /// action 範例 2
        /// </summary>
        /// <param name="name"></param>
        private void ShowMessage(string name)
        {
            Console.WriteLine($"Hi! {name}");

        }

        /// <summary>
        ///  Func 範例1
        /// </summary>
        /// <param name="action"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private string ShowSomething(string action, string message)
        {
            string result = $"動作:{action} : 訊息:{message}";
            return result;
        }

        /// <summary>
        /// Func 範例2
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string ShowSomething(string message) 
        {
            string result = $" 訊息:{message}";
            return result;
        }


        public static void Main(string[] args)
        {
            //測試 Action
            委派類型架構 deleStruct = new 委派類型架構();
            Action<string, int> act01 = deleStruct.ShowMessage;
            act01("Jack",28);
            Action<string> act02 = deleStruct.ShowMessage;
            act02("Jack");

            //測試 Func
            Func<string, string,string> func01 = deleStruct.ShowSomething;
            Console.WriteLine("回傳訊息:{0}", func01("吃", "麵包"));

            Func<string,string> func02 = deleStruct.ShowSomething;
            Console.WriteLine("回傳訊息:{0}", func02($"今天時間為{DateTime.Now}"));
        }


    }
}
