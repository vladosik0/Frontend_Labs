using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Tasks;
using BSATask.DAL.Repositories.Interfaces;
using BSATask.Domain.Exceptions;
using BSATask.Domain.Services.Interfaces;
using Task = BSATask.DAL.Entities.Task;
using TaskAsync = System.Threading.Tasks.Task;

namespace BSATask.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public TaskService(IMapper mapper, ITaskRepository taskRepository, IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }
        public async Task<List<TaskDto>> GetAllTasks()
        {
            return _mapper.Map<List<TaskDto>>(await _taskRepository.GetAllAsync());
        }

        public async Task<TaskDto> GetTaskById(int id)
        {
            return _mapper.Map<TaskDto>(await _taskRepository.GetByIdAsync(id));
        }

        public async Task<Task> GetRandomTask()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks[Random.Shared.Next(0, tasks.Count() - 1)];
        }

        public async Task<TaskCreateDto> CreateTask(TaskCreateDto taskDto)
        {
            taskDto.Id = await _taskRepository.FindMaxId(p => p.Id) + 1;

            if (!await ProjectOrPerformerExist(taskDto.ProjectId, taskDto.PerformerId))
            {
                throw new NotFoundException($"{nameof(Project)} or {nameof(User)}");
            }

            await _taskRepository.CreateAsync(_mapper.Map<Task>(taskDto));

            return taskDto;
        }

        public async Task<TaskEditDto> UpdateTask(TaskEditDto taskDto)
        {
            var taskInDb = await _taskRepository.GetByIdAsync(taskDto.Id);

            if (taskInDb == null)
            {
                throw new NotFoundException(nameof(Task), taskDto.Id);
            }

            if (!await ProjectOrPerformerExist(taskDto.ProjectId, taskDto.PerformerId))
            {
                throw new NotFoundException($"{nameof(Project)} or {nameof(User)}");
            }

            var task = _mapper.Map<Task>(taskDto);
            task.CreatedAt = taskInDb.CreatedAt;

            await _taskRepository.Update(task);

            return taskDto;
        }

        public async TaskAsync DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task != null)
            {
                await _taskRepository.Delete(task);
            }
        }

        private async Task<bool> ProjectOrPerformerExist(int projectId, int performerId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            var performer = await _userRepository.GetByIdAsync(performerId);

            return project != null && performer != null;
        }
    }
}
