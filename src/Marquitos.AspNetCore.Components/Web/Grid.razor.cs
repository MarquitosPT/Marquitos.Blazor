using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class Grid : Component, IGrid, IDisposable
    {
        [Parameter]
        public ColumnDefinitions ColumnDefinitions { get; set; }

        [Parameter]
        public RowDefinitions RowDefinitions { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public int ColSpace { get; set; }

        [Parameter]
        public int RowSpace { get; set; }

        public void SetColumnDefinitions(ColumnDefinitions columnDefinitions)
        {
            ColumnDefinitions = columnDefinitions;
            StateHasChanged();
        }

        public void SetRowDefinitions(RowDefinitions rowDefinitions)
        {
            RowDefinitions = rowDefinitions;
            StateHasChanged();
        }

        public void Dispose()
        {
            ColumnDefinitions = null;
            RowDefinitions = null;
            ChildContent = null;
        }

    }
}
