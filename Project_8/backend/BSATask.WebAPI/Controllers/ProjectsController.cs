
using BSATask.DAL.Models;
using BSATask.DAL.Models.Projects;
using BSATask.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILinqService _linqService;

        public ProjectsController(IProjectService projectService, ILinqService linqService)
        {
            _projectService = projectService;
            _linqService = linqService;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ProjectDto>))]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        /// <summary>
        /// Get project by id
        /// </summary>
        /// <param name="id">Project Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProjectDto))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            return Ok(await _projectService.GetProjectById(id));
        }

        /// <summary>
        /// Create new project
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProjectCreateDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectCreateDto>> CreateProject([FromBody] ProjectCreateDto project)
        {
            return Ok(await _projectService.CreateProject(project));
        }

        /// <summary>
        /// Edit project
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProjectEditDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectEditDto>> UpdateProject([FromBody] ProjectEditDto project, int id)
        {
            project.Id = id;
            return Ok(await _projectService.UpdateProject(project));
        }

        /// <summary>
        /// Delete project by id
        /// </summary>
        /// <param name="id">Project Id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);

            return NoContent();
        }

        /// <summary>
        /// Get the number of tasks in the projects of a specific user by id.
        /// </summary>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route(LinqRoutes.GetTasksCountInProjectsByUserIdAsync)]
        [ProducesResponseType(200, Type = typeof(Dictionary<string, int>))]
        [ProducesResponseType(204)]

        public async Task<ActionResult<Dictionary<string, int>>> GetTasksCountInProjectsByUserId(int userId)
        {
            return Ok(await _linqService.GetTasksCountInProjectsByUserId(userId));
        }

        /// <summary>
        /// Get a list of tuples (id, name) from the project collection where the project team contains more than a given number of people.
        /// </summary>
        /// <param name="teamSize">Number of people in team</param>
        [HttpGet]
        [Route(LinqRoutes.GetProjectsByTeamSizeAsync)]
        [ProducesResponseType(200, Type = typeof(List<ProjectByTeamDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<ProjectByTeamDto>>> GetProjectsByTeamSize(int teamSize)
        {
            return Ok(await _linqService.GetProjectsByTeamSize(teamSize));
        }

        /// <summary>
        /// Get ProjectInfoDto(project, project task with longest description, project task with shortest name, total number of users 
        /// on team provided project description is greater than 20 characters or number of tasks is less than 3) from project collection.
        /// </summary>
        [HttpGet]
        [Route(LinqRoutes.GetProjectsInfoAsync)]
        [ProducesResponseType(200, Type = typeof(List<ProjectInfoDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<ProjectInfoDto>>> GetProjectsInfo()
        {
            return Ok(await _linqService.GetProjectsInfo());
        }

        /// <summary>
        /// Get a sorted, filtered page from FullProjectDto 
        /// (a list of the tasks of this project, in each task the user responsible for it, the author and the project team)
        /// </summary>
        [HttpGet]
        [Route(LinqRoutes.GetSortedFilteredPageOfProjectsAsync)]
        [ProducesResponseType(200, Type = typeof(PagedList<FullProjectDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<PagedList<FullProjectDto>>> GetSortedFilteredPageOfProjects([FromQuery] PageDto pageDto)
        {
            PageModel? pageModel = null;
            FilterModel? filterModel = null;
            SortingModel? sortingModel = null;

            if (pageDto.PageSize.HasValue && pageDto.PageNumber.HasValue)
            {
                pageModel = new PageModel(pageDto.PageSize.Value, pageDto.PageNumber.Value);
            }

            if (!string.IsNullOrEmpty(pageDto.Name) ||
               !string.IsNullOrEmpty(pageDto.Description) ||
               !string.IsNullOrEmpty(pageDto.AuthorFirstName) ||
               !string.IsNullOrEmpty(pageDto.AuthorLastName) ||
               !string.IsNullOrEmpty(pageDto.TeamName))
            {
                filterModel = new FilterModel(pageDto.Name, pageDto.Description, pageDto.AuthorFirstName, pageDto.AuthorLastName, pageDto.TeamName);
            }

            if (pageDto.Property.HasValue && pageDto.Order.HasValue)
            {
                sortingModel = new SortingModel(pageDto.Property.Value, pageDto.Order.Value);
            }

            return Ok(await _linqService.GetSortedFilteredPageOfProjects(pageModel, filterModel, sortingModel));
        }
    }
}
