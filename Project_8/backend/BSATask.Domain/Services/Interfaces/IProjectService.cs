using BSATask.DAL.Models.Projects;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Domain.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProjectById(int id);
        Task<ProjectCreateDto> CreateProject(ProjectCreateDto projectDto);
        Task<ProjectEditDto> UpdateProject(ProjectEditDto projectDto);
        Task DeleteProject(int id);
    }

}
