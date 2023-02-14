
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Components
{
    public partial class CreatePhoto
    {
        CreatePhotoVM imgVM = new();
        [Inject] IPhotoServices PhotoServices { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected async Task Createimg()
        {
            await PhotoServices.CreatePhotoSrv(imgVM);
            NavigationManager.NavigateTo("/photo");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/photo");
        }
    }
}
