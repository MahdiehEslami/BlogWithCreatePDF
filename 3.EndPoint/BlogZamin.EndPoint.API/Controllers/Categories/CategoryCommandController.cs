using BlogZamin.Core.Contract.Categories.Commands.CreateCategory;
using BlogZamin.Core.Contract.Categories.Commands.DeleteCategory;
using BlogZamin.Core.Contract.Categories.Commands.UpdateCategory;
using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Categories
{
    [Route("api/[controller]")]
    public class CategoryCommandController : BaseController
    {
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategory)
            => await Create<CreateCategoryCommand, long>(createCategory);

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand deleteCategory)
           => await Delete<DeleteCategoryCommand, bool>(deleteCategory);

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategory)
            => await Edit<UpdateCategoryCommand, long>(updateCategory);
    }
}
