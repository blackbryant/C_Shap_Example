using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
 * 反射使用
 * 如果有兩個相同屬性的物件，利用反射來完成copy直到另一個物件
 * 將Item物件的值複製到CopyItem
 */
namespace A基本觀念.LINQ範例.表達式
{


    public class 表達式範例01
    {
        class Item
        {
            public int id;
            public string name;
            public float price;

        }

        class CopyItem
        {
            public int id;
            public string name;
            public float price;

        }

        public static void Main(string[] args)
        {
            Item item = new Item()
            {
                id = 1,
                name = "",
                price = 100.01f      
            };
            
            PrintObject(item);
            //用反射，性能比較不好
            CopyItem copyItem  =  ConvertAnotherObj<Item, CopyItem>(item);
            PrintObject(copyItem);

            //使用表達式用動態建立:




        }

        public static void PrintObject<T>(T obj) 
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                System.Console.WriteLine("Properties:"+item.Name+":" + item.GetValue(obj));
            }

            foreach (var item in obj.GetType().GetFields())
            {
                System.Console.WriteLine("Field:" + item.Name + ":" + item.GetValue(obj));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn">有植物件</typeparam>
        /// <typeparam name="TOut">對象物件</typeparam>
        /// <param name="tin"></param>
        /// <returns></returns>
        public static TOut ConvertAnotherObj<TIn, TOut>(TIn tin) 
        {
            TOut tout = Activator.CreateInstance<TOut>();
            foreach(var itemOut in tout.GetType().GetProperties()) 
            {
                foreach (var itemIn in tin.GetType().GetProperties()) 
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tout, itemIn.GetValue(tin));
                        break;
                    }
                
                }
            }

            foreach (var itemOut in tout.GetType().GetFields())
            {
                foreach (var itemIn in tin.GetType().GetFields())
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tout, itemIn.GetValue(tin));
                        break;
                    }

                }
            }
            return tout;
        }

        private static Dictionary<string,object> _Dict = new Dictionary<string,object>();

        public static Tout ConvertAnther2<Tin, Tout>(Tin tin) 
        {
            string key = string.Format("funckey_{0}__{1}",typeof(Tin).FullName , typeof(Tout).FullName);
            if (!_Dict.ContainsKey(key)) 
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(Tin),"p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach(var item in typeof(Tout).GetProperties()) 
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(Tin).GetProperty(item.Name));    
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }

                foreach (var item in typeof(Tout).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(Tin).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(Tout)), memberBindingList.ToArray());
                Expression<Func<Tin,Tout >> lambda = Expression.Lambda<Func<Tin, Tout>>(memberInitExpression, new ParameterExpression[]
                  {
                    parameterExpression
                });
                Func<Tin,Tout> func = lambda.Compile();
                _Dict[key] = func;
             
            }

            return ((Func<Tin, Tout>)_Dict[key]).Invoke(tin);


        }



    }

   
}
