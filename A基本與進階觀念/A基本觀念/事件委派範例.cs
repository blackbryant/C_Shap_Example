using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 事件計算機的加減乘除
 * 
 */ 
namespace A基本觀念
{
    internal class 事件委派範例
    {
        private CalculateDele _calculate;

        public delegate decimal CalculateDele(decimal x , decimal y);

        public event CalculateDele CalculateMethod
        {
            add
            {
                if (value != null)
                {
                    _calculate += value;
                }
            }
            remove 
            {
                if (value != null)
                {
                    _calculate  -= value;
                }
            }
        }

        //執行委派的方法，?檢查是否為null，如果是就不呼叫方法
        public decimal  Run(decimal x, decimal y ) 
        {
            if (_calculate == null)
            {
                return decimal.Zero;
            }
            else
            {
              return  _calculate.Invoke(x, y);
            }
        }

        public static void Main(string[] args)
        {
            //測試
            事件委派範例 calculator = new 事件委派範例();

            事件委派範例_SumClass sumClass = new 事件委派範例_SumClass();
            事件委派範例_MinusClass minuClasss = new 事件委派範例_MinusClass();

            calculator.CalculateMethod += sumClass.Sum;
            
            Console.WriteLine(calculator.Run(10, 10));
            calculator.CalculateMethod += minuClasss.Minus;
            Console.WriteLine(calculator.Run(10, 10));


        }

        
    }
}
