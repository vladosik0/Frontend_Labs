using BSATask.DAL.Extensions;
using BSATask.DAL.Models.Projects;
using BSATask.DAL.Models.Tasks;
using System.Text;

namespace BSATask.DAL.Models.Users;

public record UserInfoDto(
    UserDto User,
    ProjectDto LastProject,
    int LastProjectTasksCount,
    int NotFinishedOrCanceledTasksCount,
    TaskDto LongestTask)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(User.ToString());
        sb.AppendLine(LastProject?.ToString() ?? "User doesn't have projects");
        sb.AppendLine($"Last project tasks count: {LastProjectTasksCount}");
        sb.AppendLine($"Not finished or canceled tasks count in last project: {NotFinishedOrCanceledTasksCount}");
        sb.AppendLine($"The longest task:\n\t{LongestTask?.ToString().ChangeNewLinesToTabs() ?? "User doesn't have tasks"}");
        return sb.ToString();
    }
}
