using BlogZamin.Core.Contract.Photos.Commands.CreatePhoto;
using BlogZamin.Core.Contract.Photos.Commands.DeletePhoto;
using BlogZamin.Core.Contract.Photos.Commands.UpdatePhoto;
using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Photos
{
    [Route("api/[controller]")]
    public class PhotoCommandController : BaseController
    {
            [HttpPost("CreatePhoto")]
            public async Task<IActionResult> CreatePhoto([FromBody] CreatePhotoCommand createPhoto)
              => await Create<CreatePhotoCommand, long>(createPhoto);

            [HttpDelete("DeletePhoto")]
            public async Task<IActionResult> DeletePhoto([FromBody] DeletePhotoCommand deletePhoto)
             => await Delete<DeletePhotoCommand, bool>(deletePhoto);

            [HttpPut("UpdatePhoto")]
            public async Task<IActionResult> UpdatePhoto([FromBody] UpdatePhotoCommand updatePhoto)
                => await Edit<UpdatePhotoCommand, long>(updatePhoto);
        
    }
}
