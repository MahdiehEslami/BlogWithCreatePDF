using BlogZamin.Core.Contract.Categories.Queries;
using BlogZamin.Service.Grpc.Protos.V1.Categories;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace BlogZamin.Service.Grpc.Services.V1.Categories
{
    public class CategoryQueryService: Protos.V1.Categories.CategoryQueryService.CategoryQueryServiceBase
    {
        private readonly ICategoryQueryRepository _categoryQuerySrv;

        public CategoryQueryService(ICategoryQueryRepository categoryQuerySrv)
        {
            _categoryQuerySrv = categoryQuerySrv;
        }

        public override Task GetAll(Empty request, IServerStreamWriter<CategoryReply> responseStream, ServerCallContext context)
        {
            return base.GetAll(request, responseStream, context);
        }

        public override Task<CategoryReply> GetById(CategoryByIdRequest request, ServerCallContext context)
        {
            return base.GetById(request, context);
        }
    }
}
