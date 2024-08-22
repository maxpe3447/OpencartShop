namespace Domain.Models;

public class PaginationList<T>
{
    public IQueryable<T> List { get; set; } = Enumerable.Empty<T>().AsQueryable();
    public int TotalCount { get; set; }
}
