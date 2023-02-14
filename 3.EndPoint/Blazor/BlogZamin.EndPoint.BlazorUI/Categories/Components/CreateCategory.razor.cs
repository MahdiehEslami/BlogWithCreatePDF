using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Components
{
    public partial class CreateCategory
    {
        CreateCategoryVM CatVM = new();
        [Inject] ICategoryServices CategoryServices { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected async Task CreateCat()
        {
            await CategoryServices.CreateCategorySrv(CatVM);
            NavigationManager.NavigateTo("/category");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}
