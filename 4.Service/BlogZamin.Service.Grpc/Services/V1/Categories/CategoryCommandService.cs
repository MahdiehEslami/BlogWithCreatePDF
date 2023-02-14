using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using BlogZamin.Core.Contract;
using BlogZamin.Service.Grpc.Protos.V1.Categories;
using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Contract.Categories.Commands.CreateCategory;

namespace BlogZamin.Service.Grpc.Services.V1.Categories
{
    public class CategoryCommandService: Protos.V1.Categories.CategoryCommandService.CategoryCommandServiceBase
    {
        private readonly ICategoryCommandRepository _categoryCommandSrv;

        public CategoryCommandService(ICategoryCommandRepository categoryCommandSrv)
        {
            _categoryCommandSrv = categoryCommandSrv;
        }
        public override async Task CreateCategory(IAsyncStreamReader<CategoryCreateRequest> requestStream, IServerStreamWriter<CategoryCreateReply> responseStream, ServerCallContext context)
        {
           await foreach (var item in requestStream.ReadAllAsync())
            {
                var ccm = new CreateCategoryCommand
                {
                    Title = item.Title,
                    IsActive = item.IsActive,
                };
                await responseStream.WriteAsync(new CategoryCreateReply
                {
                    CategoryId = 5
                }); ;
            }
        }

        public override Task<CategoryUpdateReply> UpdateCategory(CategoryUpdateRequest request, ServerCallContext context)
        {
            return base.UpdateCategory(request, context);
        }

        public override Task<CategoryDeleteReply> DeleteCategory(CatByIdRequest request, ServerCallContext context)
        {
            return base.DeleteCategory(request, context);
        }
    }
}
