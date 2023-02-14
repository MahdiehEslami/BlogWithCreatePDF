using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Components
{
    public partial class ListOfCategory
    {
        [Parameter]
        public string CategoryId { get; set; }
        private PagedData<CategoryVM> pagedData;
        DeleteCategoryVM model = new();
        private string ErrorMessage;
        PageQuery pageQuery = new();
        [Inject] ICategoryServices CategoryService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await CategoryService.GetCategoryListSrv(pageQuery);

            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                pagedData = result.Data;
        }

        private async Task SelectedPage(int page)
        {
            pageQuery.PageNumber = page;
            await LoadDataAsync();
        }

        protected async Task DeleteCat()
        {
            if (long.TryParse(CategoryId, out long id) == false) return;
            model.CategoryId = id;
            await CategoryService.DeleteCategorySrv(model);
            //NavigationManager.NavigateTo("/category");
        }

        protected async Task PDFFile(string Title)
        {
                var fileName = Title;
                var fileURL = "https://localhost:44339/api/CategoryQuery/GeneratePdf?InvoiceNo=" + fileName;
                NavigationManager.NavigateTo(fileURL);
            
        }
    }
}
