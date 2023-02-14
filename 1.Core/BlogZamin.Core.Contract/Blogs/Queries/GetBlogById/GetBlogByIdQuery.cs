using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace BlogZamin.Core.Contract.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IQuery<BlogQr>
    {
        public long Id { get; set; }
    }
}
