using BlogZamin.Core.Contract.Blogs.Queries;
using BlogZamin.Core.Contract.Blogs.Queries.GetAllBlog;
using BlogZamin.Core.Contract.Blogs.Queries.GetBlogById;
using BlogZamin.Infrastructure.SQL.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace BlogZamin.Infrastructure.SQL.Queries.Blogs
{
    public class BlogQueryRepository : BaseQueryRepository<BlogZaminQueryDbContext>, IBlogQueryRepository
    {
        public BlogQueryRepository(BlogZaminQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BlogQr> GetBlogByIdQuery(GetBlogByIdQuery query)
        {
            var blog = await _dbContext.Blog
                         .Include(b => b.BlogCategories)
                             .ThenInclude(b => b.Category)
                         .Include(b => b.BlogPhotos)
                             .ThenInclude(b => b.Photo)
             .Select(b => new BlogQr
             {
                 Id = b.Id,
                 Title = b.Title,
                 Description = b.Description,
                 BusinessId = b.BusinessId,
                 BlogCategories = b.BlogCategories.Select(c => new BlogCategoryQr
                 {
                     CategoryId = c.CategoryId,
                     BlogId = c.BlogId,
                     Title = c.Category.Title,

                 }).ToList(),
                 BlogPhotos = b.BlogPhotos.Select(p => new BlogPhotoQr
                 {
                     PhotoId = p.PhotoId,
                     BlogId = p.BlogId,
                     Title = p.Photo.Title,
                     ImageUrl = p.Photo.ImageUrl
                 }).ToList()
             }).FirstOrDefaultAsync(b => b.Id.Equals(query.Id));
            return blog;
        }

        public async Task<PagedData<BlogQr>> GetAllBlogQuery(GetAllBlogQuery Bloglist)
        {
            PagedData<BlogQr> data = new PagedData<BlogQr>();

            var blogs = await _dbContext.Blog
                        .Include(b => b.BlogCategories)
                            .ThenInclude(b => b.Category)
                        .Include(b => b.BlogPhotos)
                            .ThenInclude(b => b.Photo)
                        .ToListAsync();

            data.QueryResult = blogs
            .OrderByDescending(b => b.Id)
            .Skip(Bloglist.SkipCount)
            .Take(Bloglist.PageSize)
            .Select(b => new BlogQr
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                BusinessId = b.BusinessId,
                BlogCategories = b.BlogCategories.Select(c => new BlogCategoryQr
                {
                    CategoryId = c.CategoryId,
                    BlogId = c.BlogId,
                    Title = c.Category.Title
                }).ToList(),
                BlogPhotos = b.BlogPhotos.Select(p => new BlogPhotoQr
                {
                    PhotoId = p.PhotoId,
                    BlogId = p.BlogId,
                    Title = p.Photo.Title,
                    ImageUrl = p.Photo.ImageUrl
                }).ToList()
            })
            .ToList();

            if (Bloglist.NeedTotalCount)
            {
                data.TotalCount = blogs.Count;
            }

            return data;

        }
    }
}
