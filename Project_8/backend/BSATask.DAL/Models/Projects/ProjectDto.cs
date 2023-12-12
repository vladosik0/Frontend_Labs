using System.Text;

namespace BSATask.DAL.Models.Projects;

public record ProjectDto(
    int Id,
    int AuthorId,
    int TeamId,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime Deadline)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"[{Id}]. {Name} with description: {Description}");
        sb.AppendLine($"was created at {CreatedAt.ToShortDateString()} and has a deadline at {Deadline.ToShortDateString()}");
        return sb.ToString();
    }
}
