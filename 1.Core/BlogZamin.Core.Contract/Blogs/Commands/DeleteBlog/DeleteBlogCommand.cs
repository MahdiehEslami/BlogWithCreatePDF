using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : ICommand<bool>
    {
        public long BlogId { get; set; }
    }
}
