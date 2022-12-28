using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Проект2.Converters
{
    internal class SeriesCollectionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> labels = values[0] as List<string>;
            List<int> gryzValues = values[1] as List<int>;
            if (labels == null || gryzValues == null) return null;
            SeriesCollection series = new SeriesCollection();
            for (int i = 0; i < gryzValues.Count; i++)
            {
                series.Add(new PieSeries { Title = labels[i], Values = new ChartValues<int> { gryzValues[i] } });
            }
            return series;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
