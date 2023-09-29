using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.AutoMapper範例
{
    public class PeopleTotalResolver : IValueResolver<List<People>, PeopleTotal, decimal>
    {
        public decimal Resolve(List<People> source, PeopleTotal destination, decimal destMember, ResolutionContext context)
        {
           

            decimal salaryTotal = source.Sum(x => x.Saralry);
           
            return salaryTotal;
        }
    }
}
