using BSATask.DAL.Models.Teams;

namespace BSATask.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<TeamDto>> GetAllTeams();
        Task<TeamDto> GetTeamById(int id);
        Task<TeamCreateDto> CreateTeam(TeamCreateDto teamDto);
        Task<TeamEditDto> UpdateTeam(TeamEditDto teamDto);
        System.Threading.Tasks.Task DeleteTeam(int id);
    }
}
