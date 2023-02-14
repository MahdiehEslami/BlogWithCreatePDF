using BlogZamin.Core.Contract.Blogs.Queries.GetAllBlog;
using BlogZamin.Core.Contract.Blogs.Queries.GetBlogById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Queries;

namespace BlogZamin.Core.Contract.Blogs.Queries
{
    public interface IBlogQueryRepository
    {
            Task<BlogQr> GetBlogByIdQuery(GetBlogByIdQuery query);
            Task<PagedData<BlogQr>> GetAllBlogQuery(GetAllBlogQuery query);
    }
}
