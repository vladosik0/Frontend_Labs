using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Projects;
using BSATask.DAL.Repositories.Interfaces;
using BSATask.Domain.Exceptions;
using BSATask.Domain.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;

        public ProjectService(IMapper mapper, IProjectRepository projectRepository, IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            return _mapper.Map<List<ProjectDto>>(await _projectRepository.GetAllAsync());
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            return _mapper.Map<ProjectDto>(await _projectRepository.GetByIdAsync(id));
        }

        public async Task<ProjectCreateDto> CreateProject(ProjectCreateDto projectDto)
        {
            projectDto.Id = await _projectRepository.FindMaxId(p => p.Id) + 1;

            if (!await UserOrTeamExist(projectDto.AuthorId, projectDto.TeamId))
            {
                throw new NotFoundException($"{nameof(User)} or {nameof(Team)}");
            }

            await _projectRepository.CreateAsync(_mapper.Map<Project>(projectDto));

            return projectDto;
        }
        public async Task<ProjectEditDto> UpdateProject(ProjectEditDto projectDto)
        {
            var projectInDb = await _projectRepository.GetByIdAsync(projectDto.Id);

            if (projectInDb == null)
            {
                throw new NotFoundException(nameof(Project), projectDto.Id);
            }

            if (!await UserOrTeamExist(projectDto.AuthorId, projectDto.TeamId))
            {
                throw new NotFoundException($"{nameof(User)} or {nameof(Team)}");
            }

            var project = _mapper.Map<Project>(projectDto);
            project.CreatedAt = projectInDb.CreatedAt;

            if (project.Deadline < project.CreatedAt)
            {
                throw new DateEarlierException(nameof(Project.Deadline), nameof(Project.CreatedAt));
            }

            await _projectRepository.Update(project);

            return projectDto;
        }

        public async Task DeleteProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project != null)
            {
                await _projectRepository.Delete(project);
            }
        }

        private async Task<bool> UserOrTeamExist(int authorId, int teamId)
        {
            var user = await _userRepository.GetByIdAsync(authorId);
            var team = await _teamRepository.GetByIdAsync(teamId);

            return user != null && team != null;
        }
    }
}
