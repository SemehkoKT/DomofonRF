using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Проект2.Converters
{
    internal class ListValuesToChartValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<double> values = value as List<double>;
            if (values == null) return null;
            ChartValues<ObservablePoint> observablePoints = new ChartValues<ObservablePoint>();
            for (int i = 0; i < values.Count; i++)
            {
                observablePoints.Add(new ObservablePoint(i + 1, values[i]));
            }
            return observablePoints;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
