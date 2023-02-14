using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace BlogZamin.Core.Domain.Blogs.Entities
{
    public class Blog:AggregateRoot
    {
        #region Field
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public virtual IReadOnlyList<BlogCategory> BlogCategories { get; private set; }
        public virtual IReadOnlyList<BlogPhoto> BlogPhotos { get; private set; }

        #endregion

        #region Constracture

        private Blog()
        {

        }
        public Blog(Title title, Description description, long[] categoryIdd, long[] photoIdd)
        {
            Title = title;
            Description = description;
            CreateBlogsCategory(categoryIdd);
            CreateBlogsPhoto(photoIdd);
        }

        private void CreateBlogsPhoto(long[] photoIdd)
        => BlogPhotos = photoIdd?.Select(BlogPhoto.Create).ToList();

        private void CreateBlogsCategory(long[] categoryIdd)
        => BlogCategories = categoryIdd?.Select(BlogCategory.Create).ToList();

        #endregion

        #region Method

        public void UpdateBlog(Title title,Description description)
        {
            Title = title;
            Description = description;
        }

        public static Blog CreateBlog(Title title, Description description, long[] CategoryId, long[] PhotoId) => new(title, description, CategoryId, PhotoId);

        public void BlogUpdate(Title title, Description description, long[]  categories, long[] photos)
        {
            Title = title;
            Description = description;

            BlogCategories = categories.Select(x => BlogCategory.Create(x)).ToList();

            BlogPhotos = photos.Select(x => BlogPhoto.Create(x)).ToList();
        }

        #endregion
    }
}
