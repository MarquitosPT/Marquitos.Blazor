using System;
using System.Collections.Generic;

namespace Marquitos.AspNetCore.Components.Web
{
	public interface IChart
    {
		ChartSeries GetChartSeries();
		void SetChartSeries(ChartSeries series);
	}

	public interface IChart<T> : IChart
	{
		IEnumerable<T> GetData();
		void SetData(IEnumerable<T> data);
	}
}

