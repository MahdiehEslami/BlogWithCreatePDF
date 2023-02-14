using BlogZamin.Core.Contract.Categories.Queries;
using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandlers : QueryHandler<GetCategoryByIdQuery, CategoryQr>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public GetCategoryByIdQueryHandlers(ZaminServices zaminServices, ICategoryQueryRepository categoryQueryRepository) : base(zaminServices)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public override async Task<QueryResult<CategoryQr>> Handle(GetCategoryByIdQuery query)
        {
            return Result(await _categoryQueryRepository.Execute(query));
        }

    }
}
