namespace BlogZamin.Core.Contract.Blogs.Queries
{
    public class BlogPhotoQr
    {
        public long PhotoId { get; set; }
        public long BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}