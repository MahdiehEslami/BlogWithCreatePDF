using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Components
{
    public partial class UpdateCategory
    {
        [Parameter]
        public string CategoryId { get; set; }
        string ErrorMessage;
        UpdateCategoryVM model = new();
        GetCategoryByIdVM GetModel = new();

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryServices CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(CategoryId, out long id) == false) return;
            GetModel.CategoryId= id;
            var result = await CategoryService.GetCategoryByIdSrv(GetModel);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                MapToModel(result.Data);
        }

        private void MapToModel(CategoryVM category)
        {
            model.CategoryId = category.CategoryId;
            model.Title = category.Title;
        }

        protected async Task UpdateCat()
        {
            await CategoryService.UpdateCategorySrv(model);
            NavigationManager.NavigateTo("/category");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}
