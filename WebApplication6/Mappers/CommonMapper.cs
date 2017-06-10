using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.Models;
using WebApplication6.Model;
using AutoMapper;
namespace WebApplication6.Mappers
{
    public class CommonMapper : IMapper
    {
        static  CommonMapper()
        {
            
         //   Mapper.CreateMap<UserView, User>();
         
            Mapper.Initialize(cfg => {
               cfg.CreateMap<User, UserView>()
                 .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.BirthDate.Day))
                 .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.BirthDate.Month))
                 .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src => src.BirthDate.Year));

                cfg.CreateMap<UserView, User>()              
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay)));
            });

         
        }
     
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}