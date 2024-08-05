using AutoMapper;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Drink, DrinkDto>().ReverseMap();
            CreateMap<Extra, ExtraDto>().ReverseMap();
            CreateMap<Garniture, GarnitureDto>().ReverseMap();
            CreateMap<Hamburger, HamburgerDto>().ReverseMap();
            CreateMap<HamburgerGarniture, HamburgerGarnitureDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
