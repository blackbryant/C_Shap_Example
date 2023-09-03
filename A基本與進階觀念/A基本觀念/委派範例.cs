using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/**
 *	委派是一種資料型態，委派只是先宣告事件的連結，沒有任何方法的實作， 
 * 因此需要再產生實例需要綁定方法，單一委派只能綁定一個方法;廣播委派
 * 可以綁定多個方法。這樣的好處是可以將方法封裝起來，別的模組直接根據
 * 引用進來就可以使用
 */
namespace A基本觀念
{
	public class 委派範例
	{
		public 委派範例()
		{
		}

		/// <summary>
		/// 宣告單一委派
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		delegate int SingleDelegateSum(int x, int y);


		delegate int MintipleDelegateFun(int x, int y);	

		/// <summary>
		/// 方法實例:加
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private static int Sum(int x, int y)
		{
            //Console.WriteLine($"Sum");
            return x + y;
		}

        /// <summary>
        /// 方法實例:減
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int Minus(int x, int y)
        {
            //Console.WriteLine($"Minus");
            return x - y;
        }




        public static void Main(string[] args)
		{
			//單一委派
			SingleDelegateSum sumDele = new SingleDelegateSum(Sum);
			Console.WriteLine($"單一委派:{sumDele(1, 2)}");

            //多個委派
            MintipleDelegateFun multipDele = null;
			multipDele += Sum ;
			multipDele += Sum;

			for (int i = 1; i <= 2; i++) 
			{
                Console.WriteLine($"多個委派:{multipDele.Invoke(1, 2)}");
			}
            


        }


	}
}