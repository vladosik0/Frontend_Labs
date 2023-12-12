using BSATask.DAL.Models.Tasks;
using System.Text;

namespace BSATask.DAL.Models.Users;

public record UserWithTasksDto(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime RegisteredAt,
    DateTime BirthDay,
    List<TaskDto> Tasks)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"[User#{Id}] {FirstName} {LastName} with email {Email}");
        sb.AppendLine($"was registered at {RegisteredAt.ToShortDateString()} and was born at {BirthDay.ToShortDateString()}");

        if (Tasks.Count() == 0)
        {
            sb.AppendLine("With no current tasks");
        }
        else
        {
            sb.AppendLine($"and has tasks:\n");
            foreach (var task in Tasks)
            {
                sb.AppendLine(task.ToString());
            }
        }

        return sb.ToString();
    }
}
