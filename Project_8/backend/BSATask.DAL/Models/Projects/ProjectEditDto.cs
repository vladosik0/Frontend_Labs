using System.Text.Json.Serialization;

namespace BSATask.DAL.Models.Projects
{
    public class ProjectEditDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
    }
}
