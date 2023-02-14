using BlogZamin.Core.Domain.Blogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Commands;

namespace BlogZamin.Core.Contract.Blogs.Commands
{
    public interface IBlogCommandRepository : ICommandRepository<Blog>
    {
        //Task CreateBlogCategory(List<BlogCategory> blogCategory);
        //Task CreateBlogPhoto(List<BlogPhoto> blogImage);

    }
}
