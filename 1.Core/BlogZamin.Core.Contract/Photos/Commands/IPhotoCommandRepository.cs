using BlogZamin.Core.Domain.Photos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Commands;

namespace BlogZamin.Core.Contract.Photos.Commands
{
    public interface IPhotoCommandRepository : ICommandRepository<Photo>
    {
    }
}
