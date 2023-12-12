using BSATask.DAL.Extensions;
using BSATask.DAL.Models.Tasks;
using System.Text;

namespace BSATask.DAL.Models.Projects;

public record ProjectInfoDto(
    ProjectDto Project,
    TaskDto LongestTaskByDescription,
    TaskDto ShortestTaskByName,
    int? TeamMembersCount = null)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Project.ToString());

        if (LongestTaskByDescription == null || ShortestTaskByName == null)
        {
            sb.AppendLine("Project doesn't have tasks");
        }
        else
        {
            sb.AppendLine("Longesk task by description length: ");
            sb.AppendLine("\t" + LongestTaskByDescription.ToString().ChangeNewLinesToTabs());

            sb.AppendLine("Shortest task by name length: ");
            sb.AppendLine("\t" + ShortestTaskByName.ToString().ChangeNewLinesToTabs());
        }

        if (TeamMembersCount == null)
        {
            sb.AppendLine("This project doesn't have members");
        }
        else
        {
            sb.AppendLine($"Team members count: {TeamMembersCount}");
        }

        return sb.ToString();
    }
}
