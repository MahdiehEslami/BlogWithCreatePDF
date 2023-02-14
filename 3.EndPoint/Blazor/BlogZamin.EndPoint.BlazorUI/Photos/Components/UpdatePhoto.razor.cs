
using BlogZamin.EndPoint.BlazorUI.Photos.Models;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Microsoft.AspNetCore.Components;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Components
{
    public partial class UpdatePhoto
    {
        [Parameter]
        public string PhotoId { get; set; }
        string ErrorMessage;
        UpdatePhotoVM model = new();
        GetPhotoByIdVM GetModel = new();

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPhotoServices PhotoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(PhotoId, out long id) == false) return;
            GetModel.PhotoId = id;
            var result = await PhotoService.GetPhotoByIdSrv(GetModel);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                MapToModel(result.Data);
        }

        private void MapToModel(PhotoVM Photo)
        {
            model.PhotoId = Photo.PhotoId;
            model.Title = Photo.Title;
            model.ImageUrl= Photo.ImageUrl;
        }

        protected async Task Updateimg()
        {
            await PhotoService.UpdatePhotoSrv(model);
            NavigationManager.NavigateTo("/Photo");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Photo");
        }
    }
}

