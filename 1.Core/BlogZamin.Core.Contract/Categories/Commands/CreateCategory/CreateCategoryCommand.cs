using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand:ICommand<long>
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
