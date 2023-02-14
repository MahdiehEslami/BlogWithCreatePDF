using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Domain.Categories.Entities;
using BlogZamin.Infrastructure.SQL.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Commands;

namespace BlogZamin.Infrastructure.SQL.Commands.Categories
{
    public class CategoryCommandRepository : BaseCommandRepository<Category, BlogZaminCommandDbContext>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(BlogZaminCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
