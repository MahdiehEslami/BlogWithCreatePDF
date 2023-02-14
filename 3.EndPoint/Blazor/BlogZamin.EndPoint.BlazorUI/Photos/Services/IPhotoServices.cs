using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Services
{
    public interface IPhotoServices
    {
            Task<ApiResult<long>> CreatePhotoSrv(CreatePhotoVM model);
            Task<ApiResult<PagedData<PhotoVM>>> GetPhotoListSrv(PageQuery pageQuery);
            Task<ApiResult<long>> UpdatePhotoSrv(UpdatePhotoVM model);
            Task<ApiResult<PhotoVM>> GetPhotoByIdSrv(GetPhotoByIdVM model);
            Task<ApiResult> DeletePhotoSrv(DeletePhotoVM model);
     }
}

