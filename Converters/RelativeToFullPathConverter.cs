using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Проект2.Converters
{
    public class RelativeToFullPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (string.IsNullOrWhiteSpace(path)) return "../resources/images/Error.png";
            try
            {
                return !File.Exists(path) ? "../resources/images/error.png" : Path.GetFullPath(path);
            }
            catch (Exception)
            {
                return "../resources/images/error.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
