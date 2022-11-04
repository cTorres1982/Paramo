using AutoMapper;
using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Service.Factories;
using System;

namespace Sat.Recruitment.Api.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, NormalUser>();
            CreateMap<UserEntity, SuperUser>();
            CreateMap<UserEntity, PremiumUser>();
        }
    }
}
