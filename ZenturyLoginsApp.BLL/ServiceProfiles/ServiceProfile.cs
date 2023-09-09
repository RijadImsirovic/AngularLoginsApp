using AutoMapper;
using ZenturyLoginsApp.Models.DTOs;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.BLL.ServiceProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<LoginDto, Login>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));
            CreateMap<Login, LoginDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
