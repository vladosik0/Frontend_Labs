namespace BSATask.DAL.Entities;

public class Team
{
    public int Id { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Project> Projects { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Team()
    {

    }

    public Team(int id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public override string ToString()
    {
        return $"Team[{Id}]. {Name} was created at {CreatedAt.ToShortDateString()}";
    }
}
