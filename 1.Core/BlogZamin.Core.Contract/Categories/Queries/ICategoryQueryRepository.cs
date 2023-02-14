using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using Zamin.Core.Contracts.Data.Queries;

namespace BlogZamin.Core.Contract.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
        public PagedData<CategoryQr> Execute(GetAllCategoryQuery query);
        Task<CategoryQr> Execute(GetCategoryByIdQuery query);
        Task<CategoryQr> Execute(long id);
    }
}
