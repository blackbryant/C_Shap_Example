using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.AutoMapper範例
{
    //屬性都有加上Peopl的字段
    public class DifferentPeople
    {
        public int PeopleId { get; set; }
        public string? PeopleName { get; set; }
        public decimal PeopleSaralry { get; set; }
        public string PeopleSex { get; set; }
        public DateTime PeopleBirthday { get; set; }
    }
}
