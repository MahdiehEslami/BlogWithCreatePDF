using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Services
{
    public interface ICategoryServices
    {
        Task<ApiResult<long>> CreateCategorySrv(CreateCategoryVM model);
        Task<ApiResult<PagedData<CategoryVM>>> GetCategoryListSrv(PageQuery pageQuery);
        Task<ApiResult<long>> UpdateCategorySrv(UpdateCategoryVM model);
        Task<ApiResult<CategoryVM>> GetCategoryByIdSrv(GetCategoryByIdVM model);
        Task<ApiResult> DeleteCategorySrv(DeleteCategoryVM model);
        Task<FileStream> GeneratePdf(string Title);
    }
}
