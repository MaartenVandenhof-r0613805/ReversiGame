using Model.Reversi;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace ViewModel
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Player)
            {
                if (value.ToString().Equals("W"))
                {
                    return new SolidColorBrush(Colors.NavajoWhite);
                }

                if (value.ToString().Equals("B"))
                {
                    return new SolidColorBrush(Colors.Black);
                }

                
            }
            if(value is String)
            {
                if (value.Equals("W"))
                {
                    return new SolidColorBrush(Colors.NavajoWhite);
                }
                if (value.Equals("B"))
                {
                    return new SolidColorBrush(Colors.Black);
                }
                if (value.Equals("Draw"))
                {
                    return new SolidColorBrush(Colors.Goldenrod);
                }
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
