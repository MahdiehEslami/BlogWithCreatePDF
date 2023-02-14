using BlogZamin.Core.Domain.Categories.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace BlogZamin.Core.Contract.Categories.Commands
{
    public interface ICategoryCommandRepository:ICommandRepository<Category>
    {
    }
}
