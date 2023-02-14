using BlogZamin.Core.Contract.Categories.Queries;
using BlogZamin.Core.Contract.Photos.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.Core.Contract.Blogs.Queries
{
    public class BlogQr
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BlogCategoryQr> BlogCategories { get; set; }
        public List<BlogPhotoQr> BlogPhotos { get; set; }
    }
}