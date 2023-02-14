using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;
using BlogZamin.Core.Contract.Photos.Commands;
using BlogZamin.Core.Contract.Photos.Queries;
using BlogZamin.Core.Contract.Photos.Queries.GetAllPhoto;

namespace BlogZamin.Core.ApplicationService.Photos.Queries.GetAllPhoto
{
    public class GetAllPhotoQueryHandlers : QueryHandler<GetAllPhotoQuery, PagedData<PhotoQr>>
    {
        private readonly IPhotoQueryRepository _photoQueryRepository;
        public GetAllPhotoQueryHandlers(ZaminServices zaminServices,
                                    IPhotoQueryRepository photoQueryRepository) : base(zaminServices)
        {
            _photoQueryRepository = photoQueryRepository;
        }
        public override async Task<QueryResult<PagedData<PhotoQr>>> Handle(GetAllPhotoQuery query)
        {
            try
            {
                var result = _photoQueryRepository.Execute(query);

                return Result(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
