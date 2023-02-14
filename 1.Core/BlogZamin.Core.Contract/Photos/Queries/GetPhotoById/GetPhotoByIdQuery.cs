using BlogZamin.Core.Contract.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace BlogZamin.Core.Contract.Photos.Queries.GetPhotoById
{
    public class GetPhotoByIdQuery : IQuery<PhotoQr>
    {
        public long PhotoId { get; set; }
    }
}
