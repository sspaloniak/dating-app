using AutoMapper;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;

namespace EngineerApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDTO>();
            CreateMap<Card, CardForListDto>();
        }
    }
}