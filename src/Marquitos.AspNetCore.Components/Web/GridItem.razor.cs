using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class GridItem : Component, IGridItem, IDisposable
    {
        [CascadingParameter]
        private IGrid Container { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public int Col { get; set; } = 0;

        [Parameter]
        public int ColSpan { get; set; } = 1;

        [Parameter]
        public int Row { get; set; } = 0;

        [Parameter]
        public int RowSpan { get; set; } = 1;

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            if (Container == null)
            {
                throw new Exception("The 'GridItem' must be created inside an IGrid container!");
            }
        }

        public void Dispose()
        {
            Container = null;
            ChildContent = null;
        }
    }
}
