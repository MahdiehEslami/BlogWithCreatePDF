using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Services
{
    public interface IBlogServices
    {
            Task<ApiResult<long>> CreateBlogSrv(CreateBlogVM model);
            Task<ApiResult<PagedData<BlogVM>>> GetBlogListSrv(PageQuery pageQuery);
            Task<ApiResult<long>> UpdateBlogSrv(UpdateBlogVM model);
            Task<BlogVM> GetBlogByIdSrv(GetBlogByIdVM model);
            Task<ApiResult> DeleteBlogSrv(DeleteBlogVM model);
        
    }
}
