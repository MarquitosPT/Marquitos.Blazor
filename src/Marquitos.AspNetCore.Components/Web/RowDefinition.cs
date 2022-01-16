using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    public class RowDefinition : ComponentBase, IDisposable
    {
        [CascadingParameter]
        private IRowDefinitions RowDefinitions { get; set; }

        [Parameter]
        public string Heigth { get; set; } = "1fr";

        public void Dispose()
        {
            RowDefinitions.RemoveRowDefinition(this);
            RowDefinitions = null;
        }

        protected override void OnInitialized()
        {
            if (RowDefinitions == null)
            {
                throw new Exception("The 'RowDefinition' must be created inside a RowDefinitions component!");
            }

            RowDefinitions.AddRowDefinition(this);
        }
    }
}
