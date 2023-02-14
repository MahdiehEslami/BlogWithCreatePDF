using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace BlogZamin.Core.Domain.Categories.Entities
{
    public class Category:AggregateRoot
    {
        #region Field
        public string Title { get; set; }
        public bool IsActive { get; set; }

        #endregion

        #region Constracture

        private Category()
        {

        }

        public Category(string title,bool isActive)
        {
            Title= title;
            IsActive= isActive;
        }

        #endregion

        #region Method

        public void UpdateCategory(string title)
        {
            Title= title;
        }

        public static Category Create(string title, bool isActive) => new(title, isActive);
       
        #endregion
    }
}
