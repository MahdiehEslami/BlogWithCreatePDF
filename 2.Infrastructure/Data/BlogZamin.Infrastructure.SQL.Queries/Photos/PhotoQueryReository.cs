using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;
using BlogZamin.Infrastructure.SQL.Queries.Common;
using BlogZamin.Core.Contract.Photos.Queries;
using BlogZamin.Core.Contract.Photos.Queries.GetPhotoById;
using BlogZamin.Core.Contract.Photos.Queries.GetAllPhoto;

namespace BlogZamin.Infrastructure.SQL.Queries.Photos
{
    public class PhotoQueryReository : BaseQueryRepository<BlogZaminQueryDbContext>, IPhotoQueryRepository
    {
        public PhotoQueryReository(BlogZaminQueryDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<PhotoQr> Execute(GetPhotoByIdQuery query)
          => await _dbContext.Photo.Where(c => c.Id.Equals(query.PhotoId)).Select(c => new PhotoQr()
          {
              PhotoId = c.Id,
              Title = c.Title,
              ImageUrl=c.ImageUrl,
              BusinessId=c.BusinessId,
              IsActive=c.IsActive
          }).FirstOrDefaultAsync();
        public async Task<PhotoQr> Execute(long id)
            => await _dbContext.Photo.Where(c => c.Id.Equals(id)).Select(c => new PhotoQr()
            {
                PhotoId = c.Id,
                Title = c.Title,
                BusinessId=c.BusinessId,
                IsActive=c.IsActive,
                ImageUrl=c.ImageUrl
            }).FirstOrDefaultAsync();

        public PagedData<PhotoQr> Execute(GetAllPhotoQuery catList)
        {
            PagedData<PhotoQr> result = new();

            var query = _dbContext.Photo.AsNoTracking();

            result.QueryResult = query.OrderByDescending(c => c.Id).Skip(catList.SkipCount)
                        .Take(catList.PageSize)
                        .Select(c => new PhotoQr
                        {
                            PhotoId = c.Id,
                            Title = c.Title,
                            BusinessId= c.BusinessId,
                            IsActive= c.IsActive,
                            ImageUrl= c.ImageUrl,
                        }).ToList();


            if (catList.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }

            return result;

        }
    }
}

       
