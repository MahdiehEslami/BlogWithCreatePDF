using BlogZamin.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace BlogZamin.Core.Domain.Photos.Entities
{
    public class Photo:AggregateRoot
    {
        #region Field
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        #endregion

        #region Constracture

        private Photo()
        {

        }

        public Photo(string title,string imageUrl, bool isActive)
        {
            Title = title;
            IsActive = isActive;
            ImageUrl= imageUrl;
        }

        #endregion

        #region Method

        public void UpdatePhoto(string title,string imageUrl, bool isActive)
        {
            Title = title;
            IsActive = isActive;
            ImageUrl= imageUrl;
        }

        public static Photo Create(string title,string imageUrl, bool isActive) => new(title,imageUrl, isActive);

        #endregion
    }
}
