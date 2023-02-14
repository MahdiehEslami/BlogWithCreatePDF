namespace BlogZamin.EndPoint.BlazorUI.Blogs.Models
{
    public class CreateBlogVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long[] CategoryIds { get; set; }
        public long[] PhotoIds { get; set; }
    }
}
