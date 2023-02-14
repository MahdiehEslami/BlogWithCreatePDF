using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Contract.Categories.Commands.UpdateCategory;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Categories.Command.UpdateCategoryHandlers
{
    public class UpdateCategoryCommandHandlers : CommandHandler<UpdateCategoryCommand, long>
    {

        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public UpdateCategoryCommandHandlers(ZaminServices zaminServices,
                                        ICategoryCommandRepository categoryCommandRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(UpdateCategoryCommand command)
        {
            var result = await _categoryCommandRepository.GetGraphAsync(command.CategoryId);
            if (result == null)
                return await ResultAsync(command.CategoryId, ApplicationServiceStatus.NotFound);

            result.UpdateCategory(command.Title);
            await _categoryCommandRepository.CommitAsync();
            return Ok(result.Id);
        }
    }
    }
