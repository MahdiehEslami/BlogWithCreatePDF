using BlogZamin.EndPoint.BlazorUI.Categories.Models;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Models
{
    public class PhotoVM
    {
        public long PhotoId { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
