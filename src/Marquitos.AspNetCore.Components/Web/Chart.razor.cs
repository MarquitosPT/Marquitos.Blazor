using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	public partial class Chart : Component, IChart, IDisposable
	{
        private Size _chartAreaSize = new(500, 300);

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public ChartSeries ChartSeries { get; set; }

        public void SetChartSeries(ChartSeries series)
        {
            if (ChartSeries != series)
            {
                ChartSeries = series;
                StateHasChanged();
            }
        }

        public void Dispose()
        {
            ChartSeries = null;
            ChildContent = null;
        }
    }
}

