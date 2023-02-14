using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorShared.Services;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Refit;
using System.Reflection;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Services
{
    public class BlogServices : ServiceBase, IBlogServices
    {
        private readonly IBlogAPI _blogAPI;

        public BlogServices(IBlogAPI blogAPI)
        {
            _blogAPI = blogAPI;
        }

        public async Task<ApiResult<long>> CreateBlogSrv(CreateBlogVM model)
        {
            try
            {
                var blogId = await _blogAPI.CreateBlogSrv(model);
                return ApiResult.Successfull(blogId);
            }
            catch (ApiException ex)
            {
                var errors = await ex.GetContentAsAsync<string[]>();
                return ApiResult.Failed<long>(errors.First());
            }
        }

        public async Task<ApiResult<long>> UpdateBlogSrv(UpdateBlogVM model)
        {
            try
            {
                var blogId = await _blogAPI.UpdateBlogSrv(model);
                return ApiResult.Successfull(blogId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }

        }

        public async Task<ApiResult> DeleteBlogSrv(DeleteBlogVM model)
        {
            try
            {
                await _blogAPI.DeleteBlogSrv(model);
                return ApiResult.Successfull();
            }
            catch (ApiException ex)
            {
                return await FailedResult(ex);

            }
        }

        public async Task<BlogVM> GetBlogByIdSrv(GetBlogByIdVM Getmodel)
        {
            //try
            //{
                return await _blogAPI.GetBlogByIdSrv(Getmodel);
                //return ApiResult.Successfull(blog);
            //}
            //catch (ApiException ex)
            //{
            //    //return await FailedResult<BlogVM>(ex);
            //}
        }

        public async Task<ApiResult<PagedData<BlogVM>>> GetBlogListSrv(PageQuery pageQuery)
        {
            try
            {
                var data = await _blogAPI.GetBlogListSrv(pageQuery);
                return ApiResult.Successfull(data);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PagedData<BlogVM>>(ex);
            }
        }


    }
}
