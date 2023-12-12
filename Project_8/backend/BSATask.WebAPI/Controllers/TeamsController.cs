using BSATask.DAL.Models.Teams;
using BSATask.Domain.Services.Interfaces;
using BSATask.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace BSATeam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly ILinqService _linqService;

        public TeamsController(ITeamService teamService, ILinqService linqService)
        {
            _teamService = teamService;
            _linqService = linqService;
        }

        /// <summary>
        /// Get all teams
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TeamDto>))]
        public async Task<ActionResult<List<TeamDto>>> GetTeams()
        {
            return Ok(await _teamService.GetAllTeams());
        }

        /// <summary>
        /// Get team by id
        /// </summary>
        /// <param name="id">Team id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TeamDto))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            return Ok(await _teamService.GetTeamById(id));
        }

        /// <summary>
        /// Create new team
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TeamCreateDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TeamCreateDto>> CreateTeam([FromBody] TeamCreateDto team)
        {
            return Ok(await _teamService.CreateTeam(team));
        }

        /// <summary>
        /// Edit team
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(TeamEditDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TeamEditDto>> UpdateTeam([FromBody] TeamEditDto team, int id)
        {
            team.Id = id;
            return Ok(await _teamService.UpdateTeam(team));
        }

        /// <summary>
        /// Delete team by id
        /// </summary>
        /// <param name="id">Team Id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeam(id);

            return NoContent();
        }

        /// <summary>
        /// Get a list of teams with users from the collection of teams sorted by name in ascending order
        /// all members of which were born before the given year, sorted by the user's registration date in descending order.
        /// </summary>
        /// <param name="year">The birth year</param>
        [HttpGet]
        [Route(LinqRoutes.GetSortedTeamByMembersWithYearAsync)]
        [ProducesResponseType(200, Type = typeof(List<TeamWithMembersDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<TeamWithMembersDto>>> GetSortedTeamByMembersWithYear(int year)
        {
            return Ok(await _linqService.GetSortedTeamByMembersWithYear(year));
        }
    }
}
