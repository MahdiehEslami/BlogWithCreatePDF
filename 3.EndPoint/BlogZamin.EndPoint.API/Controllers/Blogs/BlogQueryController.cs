using BlogZamin.Core.Contract.Blogs.Queries.GetAllBlog;
using BlogZamin.Core.Contract.Blogs.Queries.GetBlogById;
using BlogZamin.Core.Contract.Blogs.Queries;
using Microsoft.AspNetCore.Mvc;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Blogs
{
    [Route("api/[controller]")]
    public class BlogQueryController : BaseController
    {
        [HttpGet("GetBlogById")]
        public async Task<IActionResult> GetBlogById(GetBlogByIdQuery query)
           => await Query<GetBlogByIdQuery, BlogQr>(query);

        [HttpGet("GetBlogList")]
        public async Task<IActionResult> GetBlogList(GetAllBlogQuery query)
            => await Query<GetAllBlogQuery, PagedData<BlogQr>>(query);
    }
}
