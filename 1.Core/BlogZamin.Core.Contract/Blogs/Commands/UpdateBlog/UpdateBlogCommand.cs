using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long[] CategoryIds { get; set; }
        public long[] PhotoIds { get; set; }
        //public List<long> BlogCategories { get; set; }
        //public List<long> BlogPhotos { get; set; }

    }
}
