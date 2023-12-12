using BSATask.DAL.Models.Projects;

namespace BSATask.DAL.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> UseSortModel<T>(this IEnumerable<T> items, SortingModel model) where T : FullProjectDto
        {
            if (model == null)
            {
                return items;
            }

            return model.Order switch
            {
                SortingOrder.Ascending => model.Property switch
                {
                    SortingProperty.Name => items.OrderBy(i => i.Name),
                    SortingProperty.Description => items.OrderBy(i => i.Description),
                    SortingProperty.Deadline => items.OrderBy(i => i.Deadline),
                    SortingProperty.CreatedAt => items.OrderBy(i => i.CreatedAt),
                    SortingProperty.TasksCount => items.OrderBy(i => i.Tasks.Count()),
                    SortingProperty.AuthorFirstName => items.OrderBy(i => i.Author.FirstName),
                    SortingProperty.AuthorLastName => items.OrderBy(i => i.Author.LastName),
                    SortingProperty.TeamName => items.OrderBy(i => i.Team.Name),
                    _ => items
                },
                SortingOrder.Descending => model.Property switch
                {
                    SortingProperty.Name => items.OrderByDescending(i => i.Name),
                    SortingProperty.Description => items.OrderByDescending(i => i.Description),
                    SortingProperty.Deadline => items.OrderByDescending(i => i.Deadline),
                    SortingProperty.CreatedAt => items.OrderByDescending(i => i.CreatedAt),
                    SortingProperty.TasksCount => items.OrderByDescending(i => i.Tasks.Count()),
                    SortingProperty.AuthorFirstName => items.OrderByDescending(i => i.Author.FirstName),
                    SortingProperty.AuthorLastName => items.OrderByDescending(i => i.Author.LastName),
                    SortingProperty.TeamName => items.OrderByDescending(i => i.Team.Name),
                    _ => items
                },
                _ => items
            };
        }
    }
}
