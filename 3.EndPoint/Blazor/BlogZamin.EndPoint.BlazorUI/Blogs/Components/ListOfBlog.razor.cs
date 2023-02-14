using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Services;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Components
{
    public partial class ListOfBlog
    {
        
        public string Id { get; set; }
        private PagedData<BlogVM> pagedData;
        DeleteBlogVM model = new();
        private string ErrorMessage;
        PageQuery pageQuery = new();
        [Inject] IBlogServices blogServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await blogServices.GetBlogListSrv(pageQuery);

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

        protected async Task DeleteBlg()
        {
            await blogServices.DeleteBlogSrv(model);
            //NavigationManager.NavigateTo("/category");
        }
    }
}
