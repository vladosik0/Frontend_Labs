using AutoMapper;
using BSATask.DAL;
using BSATask.DAL.Entities;
using BSATask.DAL.Extensions;
using BSATask.DAL.Models;
using BSATask.DAL.Models.MappingProfiles;
using BSATask.DAL.Models.Projects;
using BSATask.DAL.Models.Tasks;
using BSATask.DAL.Models.Teams;
using BSATask.DAL.Models.Users;
using BSATask.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.Domain.Services
{
    public class LinqService : ILinqService
    {
        private readonly IMapper _mapper;
        private readonly BSATaskContext _context;

        public LinqService(IMapper mapper, BSATaskContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetTasksCountInProjectsByUserId(int userId)
        {
            return await _context.Projects
                    .Where(p => p.AuthorId == userId)
                    .Include(p => p.Tasks)
                    .ToDictionaryAsync(p => $"{p.Id}: {p.Name}", p => p.Tasks.Count());
        }

        public async Task<List<TaskDto>> GetCapitalTasksByUserId(int userId)
        {
            return _mapper.Map<List<TaskDto>>(await
                _context.Tasks
                .Where(t => t.PerformerId == userId && EF.Functions.Like(t.Name, "[A-Z]%"))
                .ToListAsync());
        }
        public async Task<List<ProjectByTeamDto>> GetProjectsByTeamSize(int teamSize)
        {
            return await _context.Teams
                .Include(t => t.Projects)
                .Include(t => t.Users)
                .Where(t => t.Users.Count() > teamSize)
                .SelectMany(t => t.Projects, (team, project) => new ProjectByTeamDto(project.Id, project.Name))
                .ToListAsync();
        }
        public async Task<List<TeamWithMembersDto>> GetSortedTeamByMembersWithYear(int year)
        {
            return await _context.Teams
                .OrderBy(t => t.Name)
                .Include(t => t.Users.Where(u => u.BirthDay.Year < year).OrderByDescending(u => u.RegisteredAt))
                .Where(t => t.Users.Count() != 0)
                .Select(t => new TeamWithMembersDto(t.Id, t.Name, _mapper.Map<List<UserDto>>(t.Users)))
                .ToListAsync();

        }
        public async Task<List<UserWithTasksDto>> GetSortedUsersWithSortedTasks()
        {
            return await _context.Users
                .OrderBy(u => u.FirstName)
                .Include(u => u.Tasks.OrderByDescending(t => t.Name.Length))
                .Select(u => new UserWithTasksDto(u.Id, u.FirstName, u.LastName, u.Email, u.RegisteredAt, u.BirthDay, _mapper.Map<List<TaskDto>>(u.Tasks)))
                .ToListAsync();
        }
        public async Task<UserInfoDto> GetUserInfo(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Projects)
                    .ThenInclude(p => p.Tasks)
                .SingleOrDefaultAsync(u => u.Id == userId);

            return new UserInfoDto
                       (
                            _mapper.Map<UserDto>(user),
                            _mapper.Map<ProjectDto>(user?.Projects.OrderByDescending(p => p.CreatedAt).FirstOrDefault()),
                            user?.Projects.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Tasks.Count() ?? 0,
                            user?.Projects.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Tasks.Count(t => t.State != TaskState.Done) ?? 0,
                            _mapper.Map<TaskDto>(user?.Tasks
                                                .OrderByDescending(t => (t.FinishedAt.HasValue ? t.FinishedAt : DateTime.Now) - t.CreatedAt)
                                                .FirstOrDefault())
                       );
        }
        public async Task<List<ProjectInfoDto>> GetProjectsInfo()
        {
            var projects = _context.Projects
                .Include(p => p.Team)
                    .ThenInclude(t => t.Users)
                .Include(p => p.Tasks);

            return await projects
                .Select(p => new ProjectInfoDto
                    (
                        _mapper.Map<ProjectDto>(p),
                        _mapper.Map<TaskDto>(p.Tasks.OrderByDescending(t => t.Description.Length).FirstOrDefault()),
                        _mapper.Map<TaskDto>(p.Tasks.OrderBy(t => t.Name.Length).FirstOrDefault()),
                        p.Description.Length > 20 || p.Tasks.Count() < 3 ? p.Team.Users.Count() : null
                    )
                )
                .ToListAsync();
        }
        public async Task<PagedList<FullProjectDto>> GetSortedFilteredPageOfProjects(PageModel? pageModel, FilterModel? filterModel, SortingModel? sortingModel)
        {
            var fullProjectDtoList =
                await _context.Teams
                .Include(t => t.Projects)
                    .ThenInclude(p => p.Tasks)
                .Include(t => t.Users)
                .SelectMany(t => t.Projects,
                    (team, project) =>
                    new FullProjectDto
                    (
                        project.Id,
                        project.Name,
                        project.Description,
                        project.CreatedAt,
                        project.Deadline,
                        _context.Tasks.Where(t => t.ProjectId == project.Id)
                            .Include(t => t.Performer)
                            .Select(task => new TaskWithPerformerDto
                            (
                              task.Id,
                              task.Name,
                              task.Description,
                              TaskProfile.MapTaskStateToString(task.State),
                              task.CreatedAt,
                              task.FinishedAt,
                              _mapper.Map<UserDto>(task.Performer)
                           ))
                           .ToList(),
                        _mapper.Map<UserDto>(project.Author),
                        _mapper.Map<TeamDto>(team)
                    )
                )
                .ToListAsync();

            var list =
                fullProjectDtoList
                .UseSortModel(sortingModel)
                .Where(i => i.Name.ToLower().Contains(filterModel?.Name?.ToLower() ?? ""))
                .Where(i => i.Description.ToLower().Contains(filterModel?.Description?.ToLower() ?? ""))
                .Where(i => i.Author.FirstName.ToLower().Contains(filterModel?.AuthorFirstName?.ToLower() ?? ""))
                .Where(i => i.Author.LastName.ToLower().Contains(filterModel?.AuthorLastName?.ToLower() ?? ""))
                .Where(i => i.Team.Name.ToLower().Contains(filterModel?.TeamName?.ToLower() ?? ""))
                .ToList();

            return new PagedList<FullProjectDto>
            (
                pageModel == null
                ? list
                : list.Skip((pageModel.PageNumber - 1) * pageModel.PageSize).Take(pageModel.PageSize).ToList(),
                list.Count()
            );
        }
    }
}
