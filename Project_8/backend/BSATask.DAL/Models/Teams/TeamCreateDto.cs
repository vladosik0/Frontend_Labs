using System.Text.Json.Serialization;

namespace BSATask.DAL.Models.Teams
{
    public class TeamCreateDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
    }
}
