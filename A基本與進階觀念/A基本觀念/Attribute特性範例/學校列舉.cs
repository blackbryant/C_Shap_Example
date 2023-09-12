using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本觀念.Attribute特性範例
{
    public enum 學校列舉
    {
        Kindergarten=0,
        Elementary=6,
        Junior_High_School=9,
        Senior_High_School=12,
        College=16
    }

    public class RemarkAttribute : Attribute
    {
        private string _remark;
        public RemarkAttribute(string name)
        {
            this._remark = name;    
        }
        public string Remark { set; get;  }

        public string GetRemark() {
            return _remark; 
        }

    }



}
