using BlogZamin.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;

namespace BlogZamin.Core.Contract.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : ICommand<long>
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
