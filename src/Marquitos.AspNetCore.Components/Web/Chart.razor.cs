using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	public partial class Chart<T> : Component, IChart<T>, IDisposable
	{
        private Size _chartAreaSize = new(500, 300);

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public ChartSeries ChartSeries { get; set; }

        [Parameter]
        public IEnumerable<T> Data { get; set; } 

        public IEnumerable<T> GetData()
        {
            return Data;
        }

        public void SetData(IEnumerable<T> data)
        {
            if (Data != data)
	        {
                Data = data;
                StateHasChanged();
	        }
        }

        public ChartSeries GetChartSeries()
        {
            return ChartSeries;
        }

        public void SetChartSeries(ChartSeries series)
        {
            if (ChartSeries != series)
            {
                ChartSeries = series;
                StateHasChanged();
            }
        }

        private object GetDataValue(int index, int serieIndex, string fieldName)
        {
            var item = Data.ElementAt(index);

            if (item == null)
            {
                return null;
            }

            if (fieldName != null)
            {
                var prop = item.GetType().GetProperty(fieldName);

                if (prop == null)
                {
                    return null;
                }

                return prop.GetValue(item);
            }
            else
            {
                var props = item.GetType().GetProperties();

                if (props.Length == 0)
                {
                    return null;
                }

                return props.ElementAt(serieIndex).GetValue(item);
            }
        }

        private decimal GetMaxValue()
        {
            decimal result = 0;

            if (!Data.Any())
            {
                return result;
            }

            if (ChartSeries == null || ChartSeries.Series.Count == 0)
            {
                return result;
            }

            foreach (var item in Data)
            {
                var i = 0;
                foreach (var serie in ChartSeries.Series)
                {
                    i++;

                    if (serie.FieldName != null)
                    {
                        var prop = item.GetType().GetProperty(serie.FieldName);

                        if (prop == null)
                        {
                            continue;
                        }

                        var value = Convert.ToDecimal(prop.GetValue(item));

                        result = Math.Max(result, value);
                    }
                    else
                    {
                        var props = item.GetType().GetProperties();

                        var value = Convert.ToDecimal(props.ElementAt(i).GetValue(item));

                        result = Math.Max(result, value);
                    }
                    
                }
            }

            return result;
        }

        public void Dispose()
        {
            ChartSeries = null;
            Data = null;
            ChildContent = null;
        }
    }
}

