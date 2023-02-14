using BlogZamin.Core.Contract.Photos.Commands;
using BlogZamin.Core.Domain.Photos.Entities;
using BlogZamin.Infrastructure.SQL.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace BlogZamin.Infrastructure.SQL.Commands.Photos
{
    public class PhotoCommandRepository:BaseCommandRepository<Photo, BlogZaminCommandDbContext>, IPhotoCommandRepository
    {
        public PhotoCommandRepository(BlogZaminCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
    
}
