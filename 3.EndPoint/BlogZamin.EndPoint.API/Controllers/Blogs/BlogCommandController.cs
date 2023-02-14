using BlogZamin.Core.Contract.Blogs.Commands.CreateBlog;
using BlogZamin.Core.Contract.Blogs.Commands.DeleteBlog;
using BlogZamin.Core.Contract.Blogs.Commands.UpdateBlog;
using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Blogs
{
    [Route("api/[controller]")]
    public class BlogCommandController : BaseController
    {

        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand createBlog)
            => await Create<CreateBlogCommand, long>(createBlog);

        [HttpDelete("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog([FromBody] DeleteBlogCommand deleteBlog)
           => await Delete<DeleteBlogCommand, bool>(deleteBlog);

        [HttpPut("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand updateBlog)
            => await Edit<UpdateBlogCommand, long>(updateBlog);


    }
}
