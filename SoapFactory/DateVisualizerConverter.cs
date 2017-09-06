using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SoapFactory
{
    internal class DateVisualizerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String result = "";

            if (value != null)
            {
                result = String.Format("{0:yyyy-MM-dd}", value);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = DateTime.MinValue;
            if (value != null)
            {
                if (!DateTime.TryParse((String)value, out dt))
                {
                    dt = DateTime.MinValue;
                }
            }
            return dt;
        }
    }
}
