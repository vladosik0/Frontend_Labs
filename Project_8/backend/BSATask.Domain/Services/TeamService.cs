using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Teams;
using BSATask.DAL.Repositories.Interfaces;
using BSATask.Domain.Exceptions;
using BSATask.Domain.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Domain.Services
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public TeamService(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<List<TeamDto>> GetAllTeams()
        {
            return _mapper.Map<List<TeamDto>>(await _teamRepository.GetAllAsync());
        }

        public async Task<TeamDto> GetTeamById(int id)
        {
            return _mapper.Map<TeamDto>(await _teamRepository.GetByIdAsync(id));
        }

        public async Task<TeamCreateDto> CreateTeam(TeamCreateDto teamDto)
        {
            teamDto.Id = await _teamRepository.FindMaxId(p => p.Id) + 1;
            await _teamRepository.CreateAsync(_mapper.Map<Team>(teamDto));

            return teamDto;
        }
        public async Task<TeamEditDto> UpdateTeam(TeamEditDto teamDto)
        {
            var teamInDb = await _teamRepository.GetByIdAsync(teamDto.Id);

            if (teamInDb == null)
            {
                throw new NotFoundException(nameof(Team), teamDto.Id);
            }

            var team = _mapper.Map<Team>(teamDto);
            team.CreatedAt = teamInDb.CreatedAt;

            await _teamRepository.Update(team);

            return teamDto;
        }

        public async Task DeleteTeam(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team != null)
            {
                await _teamRepository.Delete(team);
            }
        }

    }
}
