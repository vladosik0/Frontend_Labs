using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Tasks;
using Task = BSATask.DAL.Entities.Task;

namespace BSATask.DAL.Models.MappingProfiles
{
    public sealed class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>()
                .ForCtorParam(nameof(TaskDto.State), opt => opt.MapFrom(src => MapTaskStateToString(src.State)));

            CreateMap<TaskCreateDto, Task>();

            CreateMap<TaskEditDto, Task>();
        }

        public static string MapTaskStateToString(TaskState state)
        {
            return state switch
            {
                TaskState.ToDo => "To Do",
                TaskState.Done => "Done",
                TaskState.Canceled => "Canceled",
                TaskState.InProgress => "In Progress",
                _ => string.Empty
            };
        }
    }
}
