using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Column Definition component
    /// </summary>
    public class ColumnDefinition : ComponentBase, IDisposable
    {
        [CascadingParameter]
        private IColumnDefinitions ColumnDefinitions { get; set; }

        [Parameter]
        public string Width { get; set; } = "1fr";

        public void Dispose()
        {
            ColumnDefinitions.RemoveColumnDefinition(this);
            ColumnDefinitions = null;
        }

        protected override void OnInitialized()
        {
            if (ColumnDefinitions == null)
            {
                throw new Exception("The 'ColumnDefinition' must be created inside a ColumnDefinitions component!");
            }

            ColumnDefinitions.AddColumnDefinition(this);
        }
    }
}
