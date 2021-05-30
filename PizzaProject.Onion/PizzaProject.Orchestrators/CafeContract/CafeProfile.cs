using AutoMapper;

namespace PizzaProject.Orchestrators.CafeContract
{
    public class CafeProfile : Profile
    {
        public CafeProfile()
        {
            CreateMap<PizzaProject.Core.Cafe.Cafe, Cafe>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.OpenTime, opt => opt.MapFrom(src => src.OpenTime))
              .ForMember(dest => dest.CloseTime, opt => opt.MapFrom(src => src.CloseTime));
        }
    }
}
