using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}