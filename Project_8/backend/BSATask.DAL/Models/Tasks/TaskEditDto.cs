using BSATask.DAL.Entities;
using System.Text.Json.Serialization;

namespace BSATask.DAL.Models.Tasks
{
    public class TaskEditDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public int PerformerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskState State { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
