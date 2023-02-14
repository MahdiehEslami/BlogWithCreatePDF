namespace BlogZamin.Infrastructure.SQL.Queries.Common
{
    public partial class BlogPhoto
    {
        public long Id { get; set; }
        public long BlogId { get; private set; }
        public long PhotoId { get; private set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
        public Blog Blog { get; set; }
        public Photo Photo { get; set; }
    }
}
