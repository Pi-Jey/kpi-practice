using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProject.Cafeshka.Contract
{
    public class CafeshkaProfile : Profile
    {
        public CafeshkaProfile()
        {
            CreateMap<Cafe.Model.Cafe.Cafe, Cafeshka>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.OpenTime, opt => opt.MapFrom(src => src.OpenTime))
              .ForMember(dest => dest.CloseTime, opt => opt.MapFrom(src => src.CloseTime));

        }
    }
}
