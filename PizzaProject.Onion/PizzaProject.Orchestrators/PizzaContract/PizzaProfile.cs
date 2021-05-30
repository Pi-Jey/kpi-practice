using AutoMapper;

namespace PizzaProject.Orchestrators.PizzaContract
{
    public class PizzaProfile : Profile
    {
        public PizzaProfile()
        {
            CreateMap<PizzaProject.Core.Pizza.Pizza, Pizza>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
              .ForMember(dest => dest.Recipe, opt => opt.MapFrom(src => src.Recipe));
        }
    }
}
