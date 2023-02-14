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

namespace BlogZamin.Core.ApplicationService.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandlers : QueryHandler<GetAllCategoryQuery, PagedData<CategoryQr>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public GetAllCategoryQueryHandlers(ZaminServices zaminServices,
                                    ICategoryQueryRepository categoryQueryRepository) : base(zaminServices)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }
        public override async Task<QueryResult<PagedData<CategoryQr>>> Handle(GetAllCategoryQuery query)
        {
            try
            {
                var result = _categoryQueryRepository.Execute(query);

                return Result(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}