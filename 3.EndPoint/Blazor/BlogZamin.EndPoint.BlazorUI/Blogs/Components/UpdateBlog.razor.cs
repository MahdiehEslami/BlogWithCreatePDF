using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Models;
using BlogZamin.EndPoint.BlazorUI.Blogs.Services;
using BlogZamin.EndPoint.BlazorUI.Categories.Models;
using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Components
{
        public partial class UpdateBlog
        {
            [Parameter]
            public string Id { get; set; }
            UpdateBlogVM model = new();
            List<CategoryVM> categories = new();
            List<PhotoVM> photos = new();
            GetBlogByIdVM GetModel = new();
            string ErrorMessage;
            [Inject] ICategoryServices CategoryServices { get; set; }
            [Inject] IPhotoServices PhotoServices { get; set; }
            [Inject] IBlogServices BlogServices { get; set; }
            [Inject] NavigationManager NavigationManager { get; set; }
            public string[] SelectedCategories { get; set; } = Array.Empty<string>();
            public string[] SelectedPhotos { get; set; } = Array.Empty<string>();

        protected override async Task OnInitializedAsync()
            {
                if (long.TryParse(Id, out long id) == false) return;
             model.Id = id;
            //var blogs = await BlogServices.GetBlogByIdSrv(GetModel);
            //MapToModel(blogs);

            var CatResult = await CategoryServices.GetCategoryListSrv(new PageQuery { PageSize = 10 });
            var PhotoResult = await PhotoServices.GetPhotoListSrv(new PageQuery { PageSize = 10 });

            if (CatResult.Succeeded == false && PhotoResult.Succeeded == false)
                ErrorMessage = CatResult.ErrorMessage + "  " + PhotoResult.ErrorMessage;
            else
                categories = CatResult.Data.QueryResult;
                photos = PhotoResult.Data.QueryResult;
        }

            private void MapToModel(BlogVM blods)
            {
                model.Id = blods.Id;
                model.Title = blods.Title;
                model.Description = blods.Description;
                SelectedCategories = blods.Categories.Select(x => x.CategoryId.ToString())
                    .ToArray();
                SelectedPhotos = blods.Photos.Select(x => x.PhotoId.ToString())
                   .ToArray();
        }

            protected async Task UpdateBlg()
            {
                model.CategoryIds = SelectedCategories.Select(x => Convert.ToInt64(x))
                    .ToArray();
                model.PhotoIds = SelectedPhotos.Select(x => Convert.ToInt64(x))
                   .ToArray();
            await BlogServices.UpdateBlogSrv(model);
                NavigationManager.NavigateTo("/blog");
            }

            void Cancel()
            {
                NavigationManager.NavigateTo("/blog");
            }
        }
}

