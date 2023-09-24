using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

/*
 * 命名為: MouduleProfile: 模組名稱+Profile
 */
namespace B進階觀念.AutoMapper範例.ModuleProfile
{
    public  class ModuleProfile : Profile   
    {
       public ModuleProfile() 
        {
            CreateMap<Person, People>();
            CreateMap<Item, Product>();
            //AutoMapperEx01 字串比對
            CreateMap<Person, DifferentPeople>().ForMember(a => a.PeopleId,   //目標對象
                                                                                                b => b.MapFrom(src => src.Id)) //源頭
                                                                                                .ForMember(a=>a.PeopleName, b=>b.MapFrom(src => src.Name))
                                                                                                .ForMember(a=>a.PeopleSaralry, b=> b.MapFrom(src=>src.Saralry))
                ;   
         
        }


    }
}
