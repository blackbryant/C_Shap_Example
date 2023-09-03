using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A基本與進階觀念
{
    public class 類別屬性驗證
    {
        string _id;
        public string ID 
        {
            get { return _id;  }
            set 
            {
                
                if (value.Length > 15) 
                {
                    throw new ArgumentException("不能超過15");
                }
                _id = value;
            }
        
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set
            {

                if (value.Length < 8)
                {
                    throw new ArgumentException("密碼需要超過10碼");
                }
                _password = value;
            }

        }

        

    }
}
