using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.Core.Contract.Photos.Queries
{
    public class PhotoQr
    {
        public long PhotoId { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
