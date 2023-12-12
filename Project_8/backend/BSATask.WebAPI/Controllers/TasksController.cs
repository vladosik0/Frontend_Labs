
using BSATask.DAL.Models.Tasks;
using BSATask.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = BSATask.DAL.Entities.Task;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILinqService _linqService;

        public TasksController(ITaskService taskService, ILinqService linqService)
        {
            _taskService = taskService;
            _linqService = linqService;
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TaskDto>))]
        public async Task<ActionResult<List<TaskDto>>> GetTasks()
        {
            return Ok(await _taskService.GetAllTasks());
        }

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id">Task Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TaskDto))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            return Ok(await _taskService.GetTaskById(id));
        }

        /// <summary>
        /// Get random task
        /// </summary>
        [HttpGet("random")]
        [ProducesResponseType(200, Type = typeof(TaskDto))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Task>> GetRandomTask()
        {
            return Ok(await _taskService.GetRandomTask());
        }

        /// <summary>
        /// Create new task
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TaskCreateDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TaskCreateDto>> CreateTask([FromBody] TaskCreateDto task)
        {
            return Ok(await _taskService.CreateTask(task));
        }
        /// <summary>
        /// Edit task
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(TaskEditDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TaskEditDto>> UpdateTask([FromBody] TaskEditDto task, int id)
        {
            task.Id = id;
            return Ok(await _taskService.UpdateTask(task));
        }

        /// <summary>
        /// Delete task by id
        /// </summary>
        /// <param name="id">Task Id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }

        /// <summary>
        /// Get a list of tasks assigned to a specific user by id, where the task name begins with an uppercase letter.
        /// </summary>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route(LinqRoutes.GetCapitalTasksByUserIdAsync)]
        [ProducesResponseType(200, Type = typeof(List<TaskDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<TaskDto>>> GetCapitalTasksByUserId(int userId)
        {
            return Ok(await _linqService.GetCapitalTasksByUserId(userId));
        }
    }
}
