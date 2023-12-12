namespace BSATask.DAL.Models.Teams;

public record TeamDto(
    int Id,
    string Name,
    DateTime CreatedAt)
{
    public override string ToString()
    {
        return $"Team[{Id}]. {Name} was created at {CreatedAt.ToShortDateString()}";
    }
}
