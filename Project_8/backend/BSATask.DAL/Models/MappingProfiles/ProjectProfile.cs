using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Projects;

namespace BSATask.DAL.Models.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<ProjectCreateDto, Project>();

            CreateMap<ProjectEditDto, Project>();
        }
    }
}
