using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace BlogZamin.Core.Contract.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery:IQuery<CategoryQr>
    {
        public long CategoryId { get; set; }
    }
}
