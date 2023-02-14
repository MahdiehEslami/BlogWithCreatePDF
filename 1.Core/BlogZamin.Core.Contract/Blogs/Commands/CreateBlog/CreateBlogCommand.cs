using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand: ICommand<long>
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public long[] CategoryIds { get; set; }
        public long[] PhotoIds { get; set; }

    }
}
