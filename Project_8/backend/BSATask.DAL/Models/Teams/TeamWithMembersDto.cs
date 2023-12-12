using BSATask.DAL.Extensions;
using BSATask.DAL.Models.Users;
using System.Text;

namespace BSATask.DAL.Models.Teams;

public record TeamWithMembersDto(
    int Id,
    string Name,
    List<UserDto> Members)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"[Team#{Id}]. {Name}");

        foreach (var member in Members)
        {
            sb.AppendLine("\t" + member.ToString().ChangeNewLinesToTabs());
        }

        return sb.ToString();
    }
}
