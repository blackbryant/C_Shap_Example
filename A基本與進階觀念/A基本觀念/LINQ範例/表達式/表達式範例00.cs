using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.LINQ範例.表達式
{

    
    public  class 表達式範例00
    {


        public static void Main(string[] args) 
        {
            //方法:
            Func<int,int,int> func = (x, y) => x * y +2;
            int result1 = func.Invoke(12,23); 

            //表達目錄樹:語法糖，可以解析，只能一行表示
            Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
            int result2 = exp.Compile().Invoke(3,2);
            
            /////////////////////////////////////////////////////////////////
            ParameterExpression m = Expression.Parameter(typeof(int), "m");
            ParameterExpression n = Expression.Parameter(typeof(int), "n");
            var multipy = Expression.Multiply(m, n);
            var constant = Expression.Constant(2,typeof(int));
            var add = Expression.Add(multipy, constant);
            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>
                (add, new ParameterExpression[] {m,n });

            ///// 1+1
            ConstantExpression conLeft = Expression.Constant(1);
            ConstantExpression conRight = Expression.Constant(1);
            BinaryExpression binary = Expression.Add(conLeft, conRight);
            Expression<Action> actExpression = Expression.Lambda<Action>(binary, null);
            actExpression.Compile()();

            Console.WriteLine("AAAAAAAAAAAAAAA");
        
        
        
        }

    }
}
