using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using BlogZamin.Core.Contract.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;
using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Photos.Queries;
using BlogZamin.Core.Contract.Photos.Commands;
using BlogZamin.Core.Contract.Photos.Queries.GetPhotoById;

namespace BlogZamin.Core.ApplicationService.Photos.Queries.GetPhotoById
{
    public class GetPhotoByIdQueryHandlers : QueryHandler<GetPhotoByIdQuery, PhotoQr>
    {
        private readonly IPhotoQueryRepository _photoQueryRepository;

        public GetPhotoByIdQueryHandlers(ZaminServices zaminServices, IPhotoQueryRepository photoQueryRepository) : base(zaminServices)
        {
            _photoQueryRepository = photoQueryRepository;
        }

        public override async Task<QueryResult<PhotoQr>> Handle(GetPhotoByIdQuery query)
        {
            return Result(await _photoQueryRepository.Execute(query));
        }
    }
}

