using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Models
{
    public class BlogVM
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CategoryVM> Categories { get; set; } = null;
        public List<PhotoVM> Photos { get; set; } = null;

    }
}
