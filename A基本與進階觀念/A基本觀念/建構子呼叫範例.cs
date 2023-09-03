using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念
{
    public class 建構子呼叫範例
    {

        /// <summary>
        /// 產品ID
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 產品日期
        /// </summary>
        public DateTime ProductDate { get; set; }

        /// <summary>
        /// 帶三個參數
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        public 建構子呼叫範例(Guid id, string name, DateTime date) 
        {
            ProductID = id;
            ProductName = name;
            ProductDate = date; 
        }

        /// <summary>
        /// 兩個參數
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        public 建構子呼叫範例(string name, DateTime date) : this(Guid.NewGuid(), "未知產品", DateTime.Now) 
        {
            this.ProductName = name;
            this.ProductDate = date;
        }

        /// <summary>
        ///  沒有參數
        /// </summary>
        public 建構子呼叫範例() : this(Guid.NewGuid(), "未知產品", DateTime.Now)
        {

        }

        public static void Main(string[] args) 
        {
            建構子呼叫範例 c1 = new 建構子呼叫範例();
            Console.WriteLine($"產品編號{c1.ProductID},產品名稱:{c1.ProductName}, 產品日期:{c1.ProductDate}");

            建構子呼叫範例 c2 = new 建構子呼叫範例("手機",(new DateTime(2017,12,2)));
            Console.WriteLine($"產品編號{c2.ProductID},產品名稱:{c2.ProductName}, 產品日期:{c2.ProductDate}");


        }



    }
}
