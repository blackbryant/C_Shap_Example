using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.序列化範例
{
    public class FoodIterator : IIterator<Food>
    {
        private int index = 0;
        private List<Food> list;
        public Food Current 
        {
            get 
            {
                return this.list[index];    
            }
        }

        public FoodIterator(List<Food> Foods) 
        {
            this.list = Foods;
        }

        public bool MoveNext()
        {
            return this.list.Count > ++this.index;
        }

        public void Reset()
        {
            index = -1;
        }

        public IIterator<Food> GetEnumerator()
        {
           return new FoodIterator(this.list);
        }
    }

    public class Food
    {
        public Food(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { set; get; }

        public string Description { set; get; }
        public decimal Price { set; get; }
    }
}
