using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Services;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Components
{
    public partial class CreateBlog
    {
        CreateBlogVM BlgVM = new();
        List<CategoryVM> categories = new();
        List<PhotoVM> photos = new();
        string ErrorMessage;
        [Inject] ICategoryServices CategoryServices { get; set; }
        [Inject] IPhotoServices PhotoServices { get; set; }
        [Inject] IBlogServices BlogServices { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public string[] SelectedCategories { get; set; } = Array.Empty<string>();
        public string[] SelectedPhotos { get; set; } = Array.Empty<string>();

        protected override async Task OnInitializedAsync()
        {
            var CatResult = await CategoryServices.GetCategoryListSrv(new PageQuery { PageSize = 10 });
            var PhotoResult = await PhotoServices.GetPhotoListSrv(new PageQuery { PageSize = 10 });

            if (CatResult.Succeeded == false && PhotoResult.Succeeded == false)
                ErrorMessage = CatResult.ErrorMessage+"  " + PhotoResult.ErrorMessage;
            else
                categories = CatResult.Data.QueryResult;
                photos = PhotoResult.Data.QueryResult;

        }
        protected async Task CreateBlg()
        {
            BlgVM.CategoryIds = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();
            BlgVM.PhotoIds = SelectedPhotos.Select(x => Convert.ToInt64(x))
                .ToArray();
            await BlogServices.CreateBlogSrv(BlgVM);
            NavigationManager.NavigateTo("/blog");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/blog");
        }
    }
}
