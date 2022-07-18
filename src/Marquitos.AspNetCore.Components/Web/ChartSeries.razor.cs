using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	/// <summary>
    /// Defines chart series
    /// </summary>
    public partial class ChartSeries : ComponentBase, IChartSeries, IDisposable
    {
        public ChartSeries()
        {
            Series = new List<ChartSerie>();
        }

        public ChartSeries(IChart chart)
        {
            Chart = chart;
            Series = new List<ChartSerie>();
        }

        public ChartSeries(IChart chart, IEnumerable<ChartSerie> series)
        {
            Chart = chart;
            Series = new List<ChartSerie>(series);
        }

        [CascadingParameter]
        private IChart Chart { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string FieldName { get; set; }

        public ICollection<ChartSerie> Series { get; private set; }

        public void AddChartSerie(ChartSerie serie)
        {
            if (Series.Contains(serie))
            {
                return;
            }
            Series.Add(serie);
        }

        public void RemoveChartSerie(ChartSerie serie)
        {
            if (Series.Contains(serie))
            {
                Series.Remove(serie);
            }
        }

        public int GetSeriesCount()
        {
            return Series.Count;
        }

        protected override void OnInitialized()
        {
            if (Chart == null)
            {
                throw new Exception("The 'ChartSeries' must be created inside a Chart component!");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Chart.SetChartSeries(this);
            }
        }

        public void Dispose()
        {
            Chart.SetChartSeries(null);
            Chart = null;
        }
    }
}

