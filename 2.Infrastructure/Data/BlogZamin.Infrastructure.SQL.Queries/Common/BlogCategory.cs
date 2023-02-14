using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.Infrastructure.SQL.Queries.Common
{
    public partial class BlogCategory
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public long BlogId { get; private set; }
        public long CategoryId { get; private set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Blog Blog { get; set; }
        public Category Category { get; set; }
    }
}
