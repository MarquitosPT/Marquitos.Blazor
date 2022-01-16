using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class RowDefinitions : ComponentBase, IRowDefinitions, IDisposable
    {
        public RowDefinitions()
        {
            Definitions = new List<RowDefinition>();
        }

        public RowDefinitions(IEnumerable<RowDefinition> definitions)
        {
            Definitions = new List<RowDefinition>(definitions);
        }

        [CascadingParameter]
        private IGrid Grid { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public ICollection<RowDefinition> Definitions { get; private set; }

        public void AddRowDefinition(RowDefinition definition)
        {
            if (Definitions.Contains(definition))
            {
                return;
            }
            Definitions.Add(definition);
        }

        public void RemoveRowDefinition(RowDefinition definition)
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
                throw new Exception("The 'RowDefinitions' must be created inside a Grid component!");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Grid.SetRowDefinitions(this);
            }
        }

        public void Dispose()
        {
            Grid.SetRowDefinitions(null);
            Grid = null;
        }
    }
}
