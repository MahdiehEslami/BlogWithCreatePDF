using BlogZamin.Core.Contract.Categories.Commands.CreateCategory;
using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using BlogZamin.Core.Contract.Categories.Commands.DeleteCategory;

namespace BlogZamin.Core.ApplicationService.Categories.Command.DeleteCategoryHandlers
{
    public class DeleteCategoryCommandHandlers : CommandHandler<DeleteCategoryCommand, bool>
    {

        private readonly ICategoryCommandRepository _CategoryCommandRepository;

        public DeleteCategoryCommandHandlers(ZaminServices zaminServices,
                                        ICategoryCommandRepository CategoryCommandRepository) : base(zaminServices)
        {
            _CategoryCommandRepository = CategoryCommandRepository;
        }

        public override async Task<CommandResult<bool>> Handle(DeleteCategoryCommand command)
        {
            _CategoryCommandRepository.Delete(command.CategoryId);
            await _CategoryCommandRepository.CommitAsync();
            return Ok(true);
        }
    }
}
