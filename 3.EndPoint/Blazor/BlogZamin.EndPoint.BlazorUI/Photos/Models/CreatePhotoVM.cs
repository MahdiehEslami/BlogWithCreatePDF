namespace BlogZamin.EndPoint.BlazorUI.Photos.Models
{
    public class CreatePhotoVM
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
