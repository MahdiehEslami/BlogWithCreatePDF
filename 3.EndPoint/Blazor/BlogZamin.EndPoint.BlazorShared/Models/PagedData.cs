namespace BlogZamin.EndPoint.BlazorShared.Models
{
    public class PagedData<TData>
    {
        public List<TData>? QueryResult { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
