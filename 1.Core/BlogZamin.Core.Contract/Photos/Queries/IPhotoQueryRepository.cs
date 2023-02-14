
using BlogZamin.Core.Contract.Photos.Queries.GetPhotoById;
using BlogZamin.Core.Contract.Photos.Queries.GetAllPhoto;
using Zamin.Core.Contracts.Data.Queries;

namespace BlogZamin.Core.Contract.Photos.Queries
{
    public interface IPhotoQueryRepository
    {
        public PagedData<PhotoQr> Execute(GetAllPhotoQuery query);
        Task<PhotoQr> Execute(GetPhotoByIdQuery query);
        Task<PhotoQr> Execute(long id);
    }
}
