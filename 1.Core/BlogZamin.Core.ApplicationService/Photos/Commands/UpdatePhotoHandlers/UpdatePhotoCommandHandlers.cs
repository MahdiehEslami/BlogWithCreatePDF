using BlogZamin.Core.Contract.Categories.Commands.UpdateCategory;
using BlogZamin.Core.Contract.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;
using BlogZamin.Core.Contract.Photos.Commands.UpdatePhoto;
using BlogZamin.Core.Contract.Photos.Commands;

namespace BlogZamin.Core.ApplicationService.Photos.Commands.UpdatePhotoHandlers
{
    public class UpdatePhotoCommandHandlers : CommandHandler<UpdatePhotoCommand, long>
    {

        private readonly IPhotoCommandRepository _photoCommandRepository;

        public UpdatePhotoCommandHandlers(ZaminServices zaminServices,
                                        IPhotoCommandRepository photoCommandRepository) : base(zaminServices)
        {
            _photoCommandRepository = photoCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(UpdatePhotoCommand command)
        {
            var result = await _photoCommandRepository.GetGraphAsync(command.PhotoId);
            if (result == null)
                return await ResultAsync(command.PhotoId, ApplicationServiceStatus.NotFound);

            result.UpdatePhoto(command.Title,command.ImageUrl,command.IsActive);
            await _photoCommandRepository.CommitAsync();
            return Ok(result.Id);
        }
    }
}
