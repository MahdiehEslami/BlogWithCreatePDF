using BlogZamin.EndPoint.BlazorShared.Components;
using BlogZamin.EndPoint.BlazorShared.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Components
{
    public partial class ListOfPhoto
    {
        private PagedData<PhotoVM> pagedData;
        DeletePhotoVM model = new();
        private string ErrorMessage;
        PageQuery pageQuery = new();
        [Inject] IPhotoServices PhotoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await PhotoService.GetPhotoListSrv(pageQuery);

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

        protected async Task Deleteimg()
        {
            //model.PhotoId = 9;
            await PhotoService.DeletePhotoSrv(model);
            //NavigationManager.NavigateTo("/Photo");
        }
    }
}
