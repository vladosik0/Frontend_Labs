using BSATask.DAL.Models.Users;

namespace BSATask.DAL.Models.Tasks;

public record TaskWithPerformerDto(
    int Id,
    string Name,
    string Description,
    string State,
    DateTime CreatedAt,
    DateTime? FinishedAt,
    UserDto Performer)
{

}
