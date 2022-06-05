using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;

namespace Marquitos.AspNetCore.Components.Web
{
    public class ChartSerie : ComponentBase, IDisposable
    {
        [CascadingParameter]
        private IChartSeries ChartSeries { get; set; }

        [Parameter]
        public Color Color { get; set; } = Color.Empty;

        [Parameter]
        public string Name { get; set; }

        protected override void OnInitialized()
        {
            if (ChartSeries == null)
            {
                throw new Exception("The 'ChartSerie' must be created inside a ChartSeries component!");
            }

            ChartSeries.AddChartSerie(this);
        }

        protected override void OnParametersSet()
        {
            if (Name == null)
            {
                Name = $"Serie{ChartSeries.GetSeriesCount()}";
            }
        }

        public void Dispose()
        {
            ChartSeries.RemoveChartSerie(this);
            ChartSeries = null;
        }
    }
}
