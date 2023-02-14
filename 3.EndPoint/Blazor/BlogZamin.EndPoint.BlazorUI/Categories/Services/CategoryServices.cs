using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorShared.Services;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Services
{
    public class CategoryServices : ServiceBase, ICategoryServices
    {
        private readonly ICategoryAPI _categoryAPI;

        public CategoryServices(ICategoryAPI categoryAPI)
        {
            _categoryAPI = categoryAPI;
        }
        public async Task<ApiResult<long>> CreateCategorySrv(CreateCategoryVM model)
        {
            try
            {
                var categoryId = await _categoryAPI.CreateCategorySrv(model);
                return ApiResult.Successfull(categoryId);
            }
            catch (ApiException ex)
            {
                var errors = await ex.GetContentAsAsync<string[]>();
                return ApiResult.Failed<long>(errors.First());
            }

        }

        public async Task<ApiResult> DeleteCategorySrv(DeleteCategoryVM model)
        {
            try
            {
                model.CategoryId = 3;
                await _categoryAPI.DeleteCategorySrv(model);
                return ApiResult.Successfull();
            }
            catch (ApiException ex)
            {
                return await FailedResult(ex);
            }
        }

        public async Task<ApiResult<long>> UpdateCategorySrv(UpdateCategoryVM model)
        {
            try
            {
                var categoryId = await _categoryAPI.UpdateCategorySrv(model);
                return ApiResult.Successfull(categoryId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<CategoryVM>> GetCategoryByIdSrv(GetCategoryByIdVM Getmodel)
        {
            try
            {
                var category = await _categoryAPI.GetCategoryByIdSrv(Getmodel);
                return ApiResult.Successfull(category);
            }
            catch (ApiException ex)
            {
                return await FailedResult<CategoryVM>(ex);
            }
        }

        public async Task<ApiResult<PagedData<CategoryVM>>> GetCategoryListSrv(PageQuery query)
        {
            try
            {
                var data = await _categoryAPI.GetCategoryListSrv(query);
                return ApiResult.Successfull(data);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PagedData<CategoryVM>>(ex);
            }
        }

        public Task<FileStream> GeneratePdf(string Title)
        {
            var data = _categoryAPI.GeneratePdf(Title);
            return data;
            
        }
    }
}
