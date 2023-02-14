namespace BlogZamin.EndPoint.BlazorUI.Photos.Models
{
    public class UpdatePhotoVM : CreatePhotoVM
    {
        public long PhotoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
