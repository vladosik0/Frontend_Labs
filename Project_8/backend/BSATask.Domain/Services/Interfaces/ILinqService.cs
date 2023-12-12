using BSATask.DAL.Models;
using BSATask.DAL.Models.Projects;
using BSATask.DAL.Models.Tasks;
using BSATask.DAL.Models.Teams;
using BSATask.DAL.Models.Users;

namespace BSATask.Domain.Services.Interfaces
{
    public interface ILinqService
    {
        Task<Dictionary<string, int>> GetTasksCountInProjectsByUserId(int userId);
        Task<List<TaskDto>> GetCapitalTasksByUserId(int userId);
        Task<List<ProjectByTeamDto>> GetProjectsByTeamSize(int teamSize);
        Task<List<TeamWithMembersDto>> GetSortedTeamByMembersWithYear(int year);
        Task<List<UserWithTasksDto>> GetSortedUsersWithSortedTasks();
        Task<UserInfoDto> GetUserInfo(int userId);
        Task<List<ProjectInfoDto>> GetProjectsInfo();
        Task<PagedList<FullProjectDto>> GetSortedFilteredPageOfProjects(PageModel? pageModel, FilterModel? filterModel, SortingModel? sortingModel);
    }
}
