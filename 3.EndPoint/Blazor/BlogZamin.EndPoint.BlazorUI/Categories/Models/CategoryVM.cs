namespace BlogZamin.EndPoint.BlazorUI.Categories.Models
{
    public class CategoryVM
    {
        public long CategoryId { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
