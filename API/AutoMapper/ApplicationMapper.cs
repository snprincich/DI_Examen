using API.Models.DTOs.DictadorDto;
using API.Models.DTOs.UserDto;
using AutoMapper;
using API.Models.Entity;
using API.Models.DTOs.FerrariDTO;
using API.Models.DTOs.PujaDTO;

namespace API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<FerrariEntity, FerrariDTO>().ReverseMap();
            CreateMap<FerrariEntity, CreateFerrariDTO>().ReverseMap();

            CreateMap<PujaEntity, PujaDTO>().ReverseMap();
            CreateMap<PujaEntity, CreatePujaDTO>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
