using BSATask.DAL.Models.Tasks;
using Task = BSATask.DAL.Entities.Task;
using TaskAsync = System.Threading.Tasks.Task;

namespace BSATask.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasks();
        Task<TaskDto> GetTaskById(int id);
        Task<Task> GetRandomTask();
        Task<TaskCreateDto> CreateTask(TaskCreateDto taskDto);
        Task<TaskEditDto> UpdateTask(TaskEditDto taskDto);
        TaskAsync DeleteTask(int id);
    }
}
