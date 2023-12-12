using BSATask.DAL.Models.Projects;

namespace BSATask.DAL.Models
{
    public record PageDto(
        int? PageSize,
        int? PageNumber,
        SortingProperty? Property,
        SortingOrder? Order,
        string Name = null,
        string Description = null,
        string AuthorFirstName = null,
        string AuthorLastName = null,
        string TeamName = null
    )
    {

    }
}
