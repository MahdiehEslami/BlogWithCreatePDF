 using BlogZamin.Core.Contract.Categories.Commands.CreateCategory;
using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Domain.Categories.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using Microsoft.Extensions.Logging;

namespace BlogZamin.Core.ApplicationService.Categories.Command.CreateCategoryHandlers
{
    public class CreateCategoryCommandHandlers : CommandHandler<CreateCategoryCommand, long>
    {

        private readonly ICategoryCommandRepository _CategoryCommandRepository;
        private readonly ILogger<CreateCategoryCommandHandlers> _Logger;

        public CreateCategoryCommandHandlers(ZaminServices zaminServices,
                                        ICategoryCommandRepository CategoryCommandRepository,ILogger<CreateCategoryCommandHandlers> logger) : base(zaminServices)
        {
            _CategoryCommandRepository = CategoryCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(CreateCategoryCommand command)
        {
            var category = new Category(command.Title, command.IsActive);
            await _CategoryCommandRepository.InsertAsync(category);
            await _CategoryCommandRepository.CommitAsync();
            _Logger.LogDebug("Created Category{categoryId}",category.Id);
            return Ok(category.Id);
        }
    }
}
