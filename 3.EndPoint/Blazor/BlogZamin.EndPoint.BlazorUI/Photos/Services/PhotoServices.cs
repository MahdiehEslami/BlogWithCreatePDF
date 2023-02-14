using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorShared.Services;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Services
{
    public class PhotoServices : ServiceBase, IPhotoServices
    {
        private readonly IPhotoAPI _PhotoAPI;

        public PhotoServices(IPhotoAPI PhotoAPI)
        {
            _PhotoAPI = PhotoAPI;
        }
        public async Task<ApiResult<long>> CreatePhotoSrv(CreatePhotoVM model)
        {
            try
            {
                var PhotoId = await _PhotoAPI.CreatePhotoSrv(model);
                return ApiResult.Successfull(PhotoId);
            }
            catch (ApiException ex)
            {
                var errors = await ex.GetContentAsAsync<string[]>();
                return ApiResult.Failed<long>(errors.First());
            }

        }

        public async Task<ApiResult> DeletePhotoSrv(DeletePhotoVM model)
        {
            try
            {
                await _PhotoAPI.DeletePhotoSrv(model);
                return ApiResult.Successfull();
            }
            catch (ApiException ex)
            {
                return await FailedResult(ex);
            }
        }

        public async Task<ApiResult<long>> UpdatePhotoSrv(UpdatePhotoVM model)
        {
            try
            {
                var PhotoId = await _PhotoAPI.UpdatePhotoSrv(model);
                return ApiResult.Successfull(PhotoId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<PhotoVM>> GetPhotoByIdSrv(GetPhotoByIdVM Getmodel)
        {
            try
            {
                var Photo = await _PhotoAPI.GetPhotoByIdSrv(Getmodel);
                return ApiResult.Successfull(Photo);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PhotoVM>(ex);
            }
        }

        public async Task<ApiResult<PagedData<PhotoVM>>> GetPhotoListSrv(PageQuery query)
        {
            try
            {
                var data = await _PhotoAPI.GetPhotoListSrv(query);
                return ApiResult.Successfull(data);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PagedData<PhotoVM>>(ex);
            }
        }

    }
    }
