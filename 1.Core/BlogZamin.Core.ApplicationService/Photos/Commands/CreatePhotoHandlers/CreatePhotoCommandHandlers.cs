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
using BlogZamin.Core.Contract.Photos.Commands.CreatePhoto;
using BlogZamin.Core.Contract.Photos.Commands;
using BlogZamin.Core.Domain.Photos.Entities;

namespace BlogZamin.Core.ApplicationService.Photos.Commands.CreatePhotoHandlers
{
    internal class CreatePhotoCommandHandlers : CommandHandler<CreatePhotoCommand, long>
    {

        private readonly IPhotoCommandRepository _photoCommandRepository;

        public CreatePhotoCommandHandlers(ZaminServices zaminServices,
                                        IPhotoCommandRepository photoCommandRepository) : base(zaminServices)
        {
            _photoCommandRepository = photoCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(CreatePhotoCommand command)
        {
            var photo = new Photo(command.Title,command.ImageUrl, command.IsActive);
            await _photoCommandRepository.InsertAsync(photo);
            await _photoCommandRepository.CommitAsync();
            return Ok(photo.Id);
        }
    }
}
