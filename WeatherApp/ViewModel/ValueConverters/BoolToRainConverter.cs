using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;
            if (isRaining)
            {
                return "Raining";
            }
            return "Dry";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string rainingString = (string)value;

            if (rainingString == "Raining")
            {
                return true;
            }
            return false;
        }
    }
}
