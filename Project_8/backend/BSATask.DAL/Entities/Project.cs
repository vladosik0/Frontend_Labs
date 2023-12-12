using System.Text;

namespace BSATask.DAL.Entities;

public class Project
{
    public int Id { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public User Author { get; set; }
    public int? AuthorId { get; set; }
    public Team Team { get; set; }
    public int? TeamId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }

    public Project()
    {

    }

    public Project(int id, int authorId, int teamId, string name, string description, DateTime createdAt, DateTime deadline)
    {
        Id = id;
        AuthorId = authorId;
        TeamId = teamId;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Deadline = deadline;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"[{Id}]. {Name} with description: {Description} has author with id {AuthorId} and in team with id {TeamId}");
        sb.AppendLine($"was created at {CreatedAt.ToShortDateString()} and has a deadline at {Deadline.ToShortDateString()}");
        return sb.ToString();
    }
}
