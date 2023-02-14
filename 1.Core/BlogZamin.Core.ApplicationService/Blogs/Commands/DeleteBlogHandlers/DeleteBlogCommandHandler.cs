using BlogZamin.Core.Contract.Blogs.Commands.DeleteBlog;
using BlogZamin.Core.Contract.Blogs.Commands;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Blogs.Commands.DeleteBlogHandlers
{
    public class DeleteBlogCommandHandler : CommandHandler<DeleteBlogCommand, bool>
    {

        private readonly IBlogCommandRepository _blogCommandRepository;

        public DeleteBlogCommandHandler(ZaminServices zaminServices,
                                        IBlogCommandRepository blogCommandRepository) : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult<bool>> Handle(DeleteBlogCommand command)
        {
            _blogCommandRepository.DeleteGraph(command.BlogId);
            await _blogCommandRepository.CommitAsync();
            var result = true;
            return Ok(result);
        }
    }
}
