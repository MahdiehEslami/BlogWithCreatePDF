using BlogZamin.Core.Contract.Blogs.Commands;
using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Infrastructure.SQL.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Commands;
using BlogZamin.Core.Domain.Blogs.Entities;

namespace BlogZamin.Infrastructure.SQL.Commands.Blogs
{
    public class BlogCommandRepository : BaseCommandRepository<Blog, BlogZaminCommandDbContext>, IBlogCommandRepository
        {
            public BlogCommandRepository(BlogZaminCommandDbContext dbContext) : base(dbContext)
            {
            }
        }
}

