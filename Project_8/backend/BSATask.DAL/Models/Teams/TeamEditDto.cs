using System.Text.Json.Serialization;

namespace BSATask.DAL.Models.Teams
{
    public class TeamEditDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

    }
}
