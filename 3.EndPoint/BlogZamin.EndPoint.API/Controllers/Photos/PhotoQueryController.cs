using BlogZamin.Core.Contract.Photos.Queries;
using BlogZamin.Core.Contract.Photos.Queries.GetAllPhoto;
using BlogZamin.Core.Contract.Photos.Queries.GetPhotoById;
using Microsoft.AspNetCore.Mvc;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Photos
{
    [Route("api/[controller]")]
    public class PhotoQueryController : BaseController
    {
            [HttpGet("GetPhotoList")]
            public async Task<IActionResult> GetPhotoList(GetAllPhotoQuery getAllphoto)
              => await Query<GetAllPhotoQuery, PagedData<PhotoQr>>(getAllphoto);

            [HttpGet("GetPhotoById")]
            public async Task<IActionResult> GetPhotoById(GetPhotoByIdQuery query)
             => await Query<GetPhotoByIdQuery, PhotoQr>(query);
        }
    }


