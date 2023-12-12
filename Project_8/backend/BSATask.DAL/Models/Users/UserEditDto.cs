using System.Text.Json.Serialization;

namespace BSATask.DAL.Models.Users
{
    public class UserEditDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int? TeamId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
    }
}
