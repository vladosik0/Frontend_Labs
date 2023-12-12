using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Teams;

namespace BSATask.DAL.Models.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>();

            CreateMap<TeamCreateDto, Team>();

            CreateMap<TeamEditDto, Team>();
        }
    }
}
