using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 委派Event
 * 
 * 
 */ 
namespace A基本觀念
{

	public class 委派Event範例Main
	{

		private void Sleep() 
		{
			Console.WriteLine("==Sleep==="); 
		}

        private void Work()
        {
            Console.WriteLine("==Work===");
        }

        private void Wakeup()
        {
            Console.WriteLine("==Warkup===");
        }

        public static void Main(string[] args)
		{
			委派Event範例 eventExample = new 委派Event範例();
            Console.WriteLine("==委派Event範例===");
            eventExample.CallDelegateHandlerEvent += new 委派Event範例.CallDelegate(new 委派Event範例Main().Sleep);
            eventExample.CallDelegateHandlerEvent += new 委派Event範例.CallDelegate(new 委派Event範例Main().Work);
            eventExample.CallDelegateHandlerEvent += new 委派Event範例.CallDelegate(new 委派Event範例Main().Wakeup);
            //可以根據需求動態加/減需要的動作邏輯

            eventExample.Run();

        }


	}
}