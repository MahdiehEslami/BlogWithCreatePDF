using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace BlogZamin.Core.Domain.Blogs.Entities
{
    public class BlogPhoto:Entity
    {
        #region Field
        public long BlogId { get; set; }
        public long PhotoId { get; set; }

        #endregion

        #region Constracture

        private BlogPhoto()
        {

        }

        public BlogPhoto(long photoId)
        {
            PhotoId = photoId;
        }

        public BlogPhoto(long blogId, long photoId)
        {
            BlogId = blogId;
            PhotoId = photoId;
        }

        #endregion

        #region Method
        public static BlogPhoto Create(long photoId) => new(photoId);


        #endregion
    }
}
