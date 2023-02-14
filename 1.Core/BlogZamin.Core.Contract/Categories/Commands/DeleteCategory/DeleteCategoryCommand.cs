using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BlogZamin.Core.Contract.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand:ICommand<bool>
    {
        public long CategoryId { get; set; }
    }
}
