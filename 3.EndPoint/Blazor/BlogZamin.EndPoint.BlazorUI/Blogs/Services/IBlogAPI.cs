using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Services
{
    [Headers("Content-Type: application/json")]
    public interface IBlogAPI
    {
        [Post("/BlogCommand/CreateBlog")]
        Task<long> CreateBlogSrv([Body] CreateBlogVM model);

        [Get("/BlogQuery/GetBlogList")]
        Task<PagedData<BlogVM>> GetBlogListSrv(PageQuery query);

        [Put("/BlogCommand/UpdateBlog")]
        Task<long> UpdateBlogSrv([Body] UpdateBlogVM model);

        [Get("/BlogQuery/GetBlogById")]
        Task<BlogVM> GetBlogByIdSrv(GetBlogByIdVM model);

        [Delete("/BlogCommand/DeleteBlog")]
        Task DeleteBlogSrv(DeleteBlogVM model);
    }
}
