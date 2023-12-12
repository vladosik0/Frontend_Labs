using System.Text;

namespace BSATask.DAL.Models;

public record PagedList<T>(
    List<T> Items,
    int TotalCount)
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Amount of items: {TotalCount}");
        foreach (var item in Items)
        {
            sb.AppendLine(item?.ToString());
        }

        return sb.ToString();
    }
}
