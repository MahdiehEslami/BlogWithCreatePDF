using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace BlogZamin.Core.Domain.Blogs.Entities
{
    public class BlogCategory:Entity
    {
        #region Field
        public long BlogId { get; set; }
        public long CategoryId { get; set; }

        #endregion

        #region Constracture

        private BlogCategory()
        {

        }

        public BlogCategory(long categoryId)
        {
            CategoryId = categoryId;
        }

        public BlogCategory(long blogId, long categoryId)
        {
            BlogId = blogId;
            CategoryId = categoryId;
        }

        #endregion

        #region Method
        public static BlogCategory Create(long categoryId) => new(categoryId);


        #endregion
    }
}
