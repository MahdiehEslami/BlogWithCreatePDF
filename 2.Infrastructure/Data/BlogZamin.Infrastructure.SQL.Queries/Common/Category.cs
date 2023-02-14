namespace BlogZamin.Infrastructure.SQL.Queries.Common
{
    public partial class Category
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
        public List<BlogCategory> blogCategories { get; set; }
    }
}

