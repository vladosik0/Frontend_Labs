using System.Text;

namespace BSATask.DAL.Entities;

public class Task
{
    public int Id { get; set; }
    public Project Project { get; set; }
    public int? ProjectId { get; set; }
    public User Performer { get; set; }
    public int? PerformerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public Task() { }
    public Task(int id, int projectId, int performedId, string name, string description, TaskState state, DateTime createdAt, DateTime? finishedAt)
    {
        Id = id;
        ProjectId = projectId;
        PerformerId = performedId;
        Name = name;
        Description = description;
        State = state;
        CreatedAt = createdAt;
        FinishedAt = finishedAt;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Task with name: {Name} has project with id {ProjectId} and a performer with id {PerformerId}");
        sb.AppendLine($"has description: {Description}");
        sb.AppendLine($"and now in state: {State}");
        sb.AppendLine($"was created at {CreatedAt.ToShortDateString()} and" + (FinishedAt.HasValue ? $" was finished at {FinishedAt}" : "wasn't finished yet"));

        return sb.ToString();
    }
}
