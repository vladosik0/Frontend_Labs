using System.Text;

namespace BSATask.DAL.Models.Tasks;

public record TaskDto(
    int Id,
    int ProjectId,
    int PerformerId,
    string Name,
    string Description,
    string State,
    DateTime CreatedAt,
    DateTime? FinishedAt)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Task with name: {Name}");
        sb.AppendLine($"has description: {Description}");
        sb.AppendLine($"and now in state: {State}");

        return sb.ToString();
    }
}
