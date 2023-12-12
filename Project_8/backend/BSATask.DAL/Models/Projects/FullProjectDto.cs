using BSATask.DAL.Extensions;
using BSATask.DAL.Models.Tasks;
using BSATask.DAL.Models.Teams;
using BSATask.DAL.Models.Users;
using System.Text;

namespace BSATask.DAL.Models.Projects;

public record FullProjectDto(
    int Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime Deadline,
    List<TaskWithPerformerDto> Tasks,
    UserDto Author,
    TeamDto Team)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Project[{Id}]. {Name} with description {Description}");
        sb.AppendLine($"was created at {CreatedAt.ToShortDateString()} and has a deadline {Deadline.ToShortDateString()}");

        sb.AppendLine($"Has tasks count: {Tasks.Count()}");

        sb.AppendLine("Has author: ");
        sb.AppendLine("\t" + Author.ToString().ChangeNewLinesToTabs());

        sb.AppendLine("Has team: ");
        sb.AppendLine("\t" + Team.ToString().ChangeNewLinesToTabs());

        return sb.ToString();
    }
}
