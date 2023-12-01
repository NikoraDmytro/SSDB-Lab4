namespace SSDB_Lab4.Common.RequestFeatures;

public class PagedList<T>
{
    public IEnumerable<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(): this(Enumerable.Empty<T>(), 0, 0, 0)
    {
    }

    public PagedList(
        IEnumerable<T> items, 
        int count, 
        int pageNumber, 
        int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        Items = items;
    }
}