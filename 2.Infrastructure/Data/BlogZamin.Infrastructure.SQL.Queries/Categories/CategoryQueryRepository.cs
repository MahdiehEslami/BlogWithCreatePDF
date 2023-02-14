using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using BlogZamin.Core.Contract.Categories.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;
using BlogZamin.Infrastructure.SQL.Queries.Common;

namespace BlogZamin.Infrastructure.SQL.Queries.Categories
{
    public class CategoryQueryRepository : BaseQueryRepository<BlogZaminQueryDbContext>,ICategoryQueryRepository
    {
        public CategoryQueryRepository(BlogZaminQueryDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<CategoryQr> Execute(GetCategoryByIdQuery query)
          => await _dbContext.Category.Where(c => c.Id.Equals(query.CategoryId)).Select(c => new CategoryQr()
          {
              CategoryId = c.Id,
              BusinessId = c.BusinessId,
              IsActive=c.IsActive,
              Title = c.Title,
          }).FirstOrDefaultAsync();

        public async Task<CategoryQr> Execute(long id)
            => await _dbContext.Category.Where(c => c.Id.Equals(id)).Select(c => new CategoryQr()
            {
                CategoryId = c.Id,
                BusinessId = c.BusinessId,
                IsActive = c.IsActive,
                Title = c.Title,
            }).FirstOrDefaultAsync();

        public PagedData<CategoryQr> Execute(GetAllCategoryQuery catList)
        {
            PagedData<CategoryQr> result = new();

            var query = _dbContext.Category.AsNoTracking();

            result.QueryResult = query.OrderByDescending(c => c.Id).Skip(catList.SkipCount)
                        .Take(catList.PageSize)
                        .Select(c => new CategoryQr
                        {
                            CategoryId = c.Id,
                            Title = c.Title,
                            IsActive= c.IsActive,
                            BusinessId =c.BusinessId
                        }).ToList();


            if (catList.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }

            return result;

        }
    }
}

        


