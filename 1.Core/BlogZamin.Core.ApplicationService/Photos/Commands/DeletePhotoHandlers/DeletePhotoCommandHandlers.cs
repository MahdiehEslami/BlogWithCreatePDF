using BlogZamin.Core.Contract.Categories.Commands.DeleteCategory;
using BlogZamin.Core.Contract.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using BlogZamin.Core.Contract.Photos.Commands;
using BlogZamin.Core.Contract.Photos.Commands.DeletePhoto;

namespace BlogZamin.Core.ApplicationService.Photos.Commands.DeletePhotoHandlers
{
    internal class DeletePhotoCommandHandlers : CommandHandler<DeletePhotoCommand, bool>
    {

        private readonly IPhotoCommandRepository _photoCommandRepository;

        public DeletePhotoCommandHandlers(ZaminServices zaminServices,
                                        IPhotoCommandRepository PhotoCommandRepository) : base(zaminServices)
        {
            _photoCommandRepository = PhotoCommandRepository;
        }

        public override async Task<CommandResult<bool>> Handle(DeletePhotoCommand command)
        {
            _photoCommandRepository.Delete(command.PhotoId);
            await _photoCommandRepository.CommitAsync();
            return Ok(true);
        }
    }
}
