namespace BlogZamin.EndPoint.BlazorUI.Categories.Models
{
    public class UpdateCategoryVM : CreateCategoryVM
    {
        public long CategoryId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
