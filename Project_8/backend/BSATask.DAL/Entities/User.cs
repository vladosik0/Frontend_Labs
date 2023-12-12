using System.Text;

namespace BSATask.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public Team Team { get; set; }
    public int? TeamId { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
    public DateTime BirthDay { get; set; }

    public User()
    {

    }

    public User(int id, int? teamId, string firstName, string lastName, string email, DateTime registeredAt, DateTime birthDay)
    {
        Id = id;
        TeamId = teamId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        RegisteredAt = registeredAt;
        BirthDay = birthDay;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"[User#{Id}] {FirstName} {LastName} with email {Email}" +
            (TeamId.HasValue ? $"and in team with id {TeamId}" : "without team"));
        sb.AppendLine($"was registered at {RegisteredAt.ToShortDateString()} and was born at {BirthDay.ToShortDateString()}");

        return sb.ToString();
    }
}
