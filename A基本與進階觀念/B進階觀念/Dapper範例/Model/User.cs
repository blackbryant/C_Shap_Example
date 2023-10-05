using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.Dapper範例.Model
{
    public class User : BaseEntity
    {
        public int NO  { get; set; }
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }

    }
}
