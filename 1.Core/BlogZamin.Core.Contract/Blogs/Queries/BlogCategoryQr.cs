namespace BlogZamin.Core.Contract.Blogs.Queries
{
    public class BlogCategoryQr
    {
        public long CategoryId { get; set; }
        public long BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}