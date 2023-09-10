using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/**
 *	委派是
 *	
 *	
 *	
 *	
 */
namespace A基本觀念
{
	public class 委派Event範例
	{
		public delegate void CallDelegate(); 

		 // 實作一個動作接口
		 //事件: 委託的實例，用來限制變數被外部調用/直接賦值
		 // 繼承也無法調用
         public event CallDelegate CallDelegateHandlerEvent;

		public void Run()
		{
			//呼叫固定方法
			Console.WriteLine($"method:{this.GetType().Name}");
			if (CallDelegateHandlerEvent != null) 
			{
                //呼叫動態方法
                CallDelegateHandlerEvent.Invoke();
			}
		}

	}
}