using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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


    public class 表達式範例02
    {
        class Item
        {

            public int id;
            public string name;
            public float price;

        }

        class CopyItem
        {
            [Mapper(Name = "id")]
            public int id;

            [Mapper(Name = "name")]
            public string itemName;
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

                foreach (var item in typeof(Tout).GetCustomAttributes(typeof(MapperAttribute)))
                {
                    



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
