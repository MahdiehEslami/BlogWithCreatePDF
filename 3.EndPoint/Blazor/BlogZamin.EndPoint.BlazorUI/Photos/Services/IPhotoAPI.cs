using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Services
{
   [Headers("Content-Type: application/json")]
    public interface IPhotoAPI
    {
        [Post("/PhotoCommand/CreatePhoto")]
        Task<long> CreatePhotoSrv([Body] CreatePhotoVM model);

        [Get("/PhotoQuery/GetPhotoList")]
        Task<PagedData<PhotoVM>> GetPhotoListSrv(PageQuery query);

        [Put("/PhotoCommand/UpdatePhoto")]
        Task<long> UpdatePhotoSrv([Body] UpdatePhotoVM model);

        [Get("/PhotoQuery/GetPhotoById")]
        Task<PhotoVM> GetPhotoByIdSrv(GetPhotoByIdVM model);

        [Delete("/PhotoCommand/DeletePhoto")]
        Task DeletePhotoSrv(DeletePhotoVM model);
    }
}
