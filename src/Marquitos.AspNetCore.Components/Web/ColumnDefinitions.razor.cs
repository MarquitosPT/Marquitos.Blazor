using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Defines Grid columns and sizes
    /// </summary>
    public partial class ColumnDefinitions : ComponentBase, IColumnDefinitions, IDisposable
    {
        public ColumnDefinitions()
        {
            Definitions = new List<ColumnDefinition>();
        }

        public ColumnDefinitions(IEnumerable<ColumnDefinition> definitions)
        {
            Definitions = new List<ColumnDefinition>(definitions);
        }

        [CascadingParameter]
        private IGrid Grid { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public ICollection<ColumnDefinition> Definitions { get; private set; }

        public void AddColumnDefinition(ColumnDefinition definition)
        {
            if (Definitions.Contains(definition))
            {
                return;
            }
            Definitions.Add(definition);
        }

        public void RemoveColumnDefinition(ColumnDefinition definition)
        {
            if (Definitions.Contains(definition))
            {
                Definitions.Remove(definition);
            }
        }

        protected override void OnInitialized()
        {
            if (Grid == null)
            {
                throw new Exception("The 'ColumnDefinitions' must be created inside a Grid component!");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Grid.SetColumnDefinitions(this);
            }
        }

        public void Dispose()
        {
            Grid.SetColumnDefinitions(null);
            Grid = null;
        }
    }
}
