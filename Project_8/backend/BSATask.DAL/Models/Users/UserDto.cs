using System.Text;

namespace BSATask.DAL.Models.Users;

public record UserDto(
    int Id,
    int? TeamId,
    string FirstName,
    string LastName,
    string Email,
    DateTime RegisteredAt,
    DateTime BirthDay)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"[User#{Id}] {FirstName} {LastName} with email {Email}");
        sb.AppendLine($"was registered at {RegisteredAt.ToShortDateString()} and was born at {BirthDay.ToShortDateString()}");

        return sb.ToString();
    }
}
