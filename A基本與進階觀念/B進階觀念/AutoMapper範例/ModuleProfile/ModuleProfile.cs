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
            //AutoMapperEx02 字串比對
            CreateMap<Person, DifferentPeople>().ForMember(a => a.PeopleId,   //目標對象
                                                                                                 b => b.MapFrom(src => src.Id)) //源頭
                                                                                                .ForMember(a => a.PeopleName, b => b.MapFrom(src => src.Name))
                                                                                                .ForMember(a => a.PeopleSaralry, b => b.MapFrom(src => src.Saralry))
                                                                                                .ForMember(a => a.PeopleSex, b => b.Ignore()) //忽略不檢查
                                                                                                .ForMember(a => a.PeopleBirthday, b => b.Ignore()); //忽略不檢查
            ;


            //AutoMapperEx03 反轉Mapping
            CreateMap<Order, OrderDTO>().ReverseMap();
            //CreateMap<Order, OrderDTO>(); 如果沒有加上ReverseMap的在做反轉的會出現錯誤

            //AutoMapperEx03 處理繼承先處理父類別，在Include子類別
           // CreateMap<Person, People>().Include<ChildPerson, ChildPeople>();
            //子類別可以單獨轉換
            CreateMap<ChildPerson, ChildPeople>();

            //AutoMapperEx04:嵌套映射
            CreateMap<Order, InnerOrder>();
            CreateMap<Customer,InnerCustomer>();

            //AutoMapperEx04:自定义类型转换器
            CreateMap<Person, Account>();
            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<decimal, int>().ConvertUsing(new String2IntTypeConverter());
            CreateMap<int, string>().ConvertUsing(new Int2StringTypeConverter());


            //AutoMapperEx05:投影
            CreateMap<Person, PersonForm>().ForMember(a => a.Year, b => b.MapFrom(src => src.Birthday.Year))
                                                                    .ForMember(a => a.Month, b=> b.MapFrom(src => src.Birthday.Month))
                                                                    .ForMember(a=> a.Day, b=> b.MapFrom(src=>src.Birthday.Day))
                ;




        }


    }

   
}
