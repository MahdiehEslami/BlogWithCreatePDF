using BlogZamin.Core.Contract.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace BlogZamin.Core.Contract.Photos.Queries.GetAllPhoto
{
    public class GetAllPhotoQuery : PageQuery<PagedData<PhotoQr>>
    {
    }
}
