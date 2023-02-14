using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.Core.Contract.Categories.Queries
{
    public class CategoryQr
    {
        public long CategoryId { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
