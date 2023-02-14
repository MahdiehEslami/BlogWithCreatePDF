using BlogZamin.EndPoint.BlazorShared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.EndPoint.BlazorShared.Components
{
    public partial class Pagination
    {
        [Parameter]
        public int CurrentPage { get; set; }
        [Parameter]
        public int PageSize { get; set; }
        [Parameter]
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private List<PagingLink> _links;

        protected override void OnParametersSet()
        {
            TotalPages = (TotalCount + PageSize - 1) / PageSize;
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>
            {
                new PagingLink(CurrentPage - 1, CurrentPage > 1, "Previous")
            };

            for (int i = 1; i <= TotalPages; i++)
            {
                if (i >= CurrentPage - Spread && i <= CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = CurrentPage == i });
                }
            }

            _links.Add(new PagingLink(CurrentPage + 1, CurrentPage < TotalPages, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == CurrentPage || !link.Enabled)
                return;

            CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
