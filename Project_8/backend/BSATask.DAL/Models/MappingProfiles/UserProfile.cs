using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Users;

namespace BSATask.DAL.Models.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserCreateDto, User>();

            CreateMap<UserEditDto, User>();
        }
    }
}
