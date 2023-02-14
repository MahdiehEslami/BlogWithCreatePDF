using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Services
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryAPI
    {
        [Post("/CategoryCommand/CreateCategory")]
        Task<long> CreateCategorySrv([Body] CreateCategoryVM model);

        [Get("/CategoryQuery/GetCategoryList")]
        Task<PagedData<CategoryVM>> GetCategoryListSrv(PageQuery query);

        [Put("/CategoryCommand/UpdateCategory")]
        Task<long> UpdateCategorySrv([Body] UpdateCategoryVM model);

        [Get("/CategoryQuery/GetCategoryById")]
        Task<CategoryVM> GetCategoryByIdSrv(GetCategoryByIdVM model);

        [Delete("/CategoryCommand/DeleteCategory")]
        Task DeleteCategorySrv(DeleteCategoryVM model);

        [Get("/CategoryQuery/GeneratePdf")]
        Task<FileStream> GeneratePdf(string Title);
    }
}
