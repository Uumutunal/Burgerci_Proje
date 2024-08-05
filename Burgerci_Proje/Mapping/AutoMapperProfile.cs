using AutoMapper;
using BLL.DTOs;
using Burgerci_Proje.Models;

namespace Burgerci_Proje.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DrinkDto, DrinkViewModel>().ReverseMap();
            CreateMap<ExtraDto, ExtraViewModel>().ReverseMap();
            CreateMap<GarnitureDto, GarnitureViewModel>().ReverseMap();
            CreateMap<HamburgerDto, HamburgerViewModel>().ReverseMap();
            CreateMap<HamburgerGarnitureDto, HamburgerGarnitureViewModel>().ReverseMap();
            CreateMap<MenuDto, MenuViewModel>().ReverseMap();
            CreateMap<OrderDetailDto, OrderDetailViewModel>().ReverseMap();
            CreateMap<OrderDto, OrderViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
        }
    }
}
