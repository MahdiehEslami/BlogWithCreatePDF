using BlogZamin.Core.Domain.Blogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.Infrastructure.SQL.Queries.Common
{
    public partial class Blog
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;
        public List<BlogCategory> BlogCategories { get; set; }
        public List<BlogPhoto> BlogPhotos { get; set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
       
    }

}
