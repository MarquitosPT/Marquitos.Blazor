namespace Marquitos.AspNetCore.Components.Web
{
    internal interface IChartSeries
    {
        void AddChartSerie(ChartSerie serie);
        void RemoveChartSerie(ChartSerie serie);

        int GetSeriesCount();
    }
}
