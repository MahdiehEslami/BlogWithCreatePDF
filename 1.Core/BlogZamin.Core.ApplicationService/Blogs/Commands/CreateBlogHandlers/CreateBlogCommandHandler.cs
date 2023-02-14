using BlogZamin.Core.Contract.Blogs.Commands.CreateBlog;
using BlogZamin.Core.Contract.Blogs.Commands;
using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Domain.Blogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Blogs.Commands.CreateBlogHandlers
{
    public class CreateBlogCommandHandler : CommandHandler<CreateBlogCommand, long>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly IBlogCommandRepository _blogCommandRepository;

        public CreateBlogCommandHandler(ZaminServices zaminServices, ICategoryCommandRepository categoryCommandRepository,
                                        IBlogCommandRepository blogCommandRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(CreateBlogCommand command)
        {
            Blog blog = Blog.CreateBlog(command.Title, command.Description,command.CategoryIds,command.PhotoIds);
            await _blogCommandRepository.InsertAsync(blog);
            await _blogCommandRepository.CommitAsync();
            return Ok(blog.Id);
        }
    }
}

