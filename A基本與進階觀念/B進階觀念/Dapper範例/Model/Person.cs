using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.Dapper範例.Model
{
    public  class Person
    {

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 電子郵件
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// 創建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// IpAddress
        /// </summary>
        public string? IpAddress { get; set; }




    }
}
