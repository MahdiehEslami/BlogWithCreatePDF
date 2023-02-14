using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommand : ICommand<long>
    {
        public long PhotoId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
