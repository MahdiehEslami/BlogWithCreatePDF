using BlogZamin.Core.Contract.Blogs.Commands.UpdateBlog;
using BlogZamin.Core.Contract.Blogs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Blogs.Commands.UpdateBlogHandlers
{
    public class UpdateBlogCommandHandler : CommandHandler<UpdateBlogCommand, long>
    {

        private readonly IBlogCommandRepository _blogCommandRepository;

        public UpdateBlogCommandHandler(ZaminServices zaminServices,
                                        IBlogCommandRepository blogCommandRepository) : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(UpdateBlogCommand command)
        {
            var result = await _blogCommandRepository.GetGraphAsync(command.Id);
            if (result == null)
            {
                return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);
            }
            result.BlogUpdate(command.Title, command.Description, command.CategoryIds, command.PhotoIds);
            await _blogCommandRepository.CommitAsync();
            return Ok(result.Id);
        }
    }
}