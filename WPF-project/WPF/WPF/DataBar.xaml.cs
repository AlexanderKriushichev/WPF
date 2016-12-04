using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для DataBar.xaml
    /// </summary>
    public partial class DataBar : UserControl
    {

        public static readonly DependencyProperty PlusBrushProperty = DependencyProperty.Register("PlusBrush", typeof(Brush), typeof(DataBar));
        /// <summary>
        /// Цвет кисти в положительном значении
        /// </summary>
        public Brush PlusBrush
        {
            get { return (Brush)this.GetValue(PlusBrushProperty); }
            set { this.SetValue(PlusBrushProperty, value); }
        }

        public static readonly DependencyProperty MinusBrushProperty = DependencyProperty.Register("MinusBrush", typeof(Brush), typeof(DataBar));
        /// <summary>
        /// Цвет кисти в отрицательном значении
        /// </summary>
        public Brush MinusBrush
        {
            get { return (Brush)this.GetValue(MinusBrushProperty); }
            set { this.SetValue(MinusBrushProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(float), typeof(DataBar));
        /// <summary>
        /// Значение
        /// </summary>
        public float Value
        {
            get { return (float)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty RangeProperty = DependencyProperty.Register("Range", typeof(float), typeof(DataBar));
        /// <summary>
        /// Диапазон
        /// </summary>
        public float Range
        {
            get { return (float)this.GetValue(RangeProperty); }
            set { this.SetValue(RangeProperty, value); }
        }

        public DataBar()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Класс конвертации значения и диапозона в границы для положительного квадрата
    /// </summary>
    public class RightMarginConverter : IMultiValueConverter
    {

        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Application.Current == null ||
                Application.Current.GetType() != typeof(App))
                return false;
            double value = (float)values[0];
            double range = (float)values[1];
            double width = (double)values[2];
            Thickness thick;
            if (value >= 0)
            {
                thick = new Thickness(width / 2, 0, range != 0 ? width / 2 - width / 2 * (value / range) : 0, 0);
            }
            else
            {
                thick = new Thickness(width / 2, 0, width / 2, 0);
            }
            return thick;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// Класс конвертации значения и диапозона в границы для отрицательного квадрата
    /// </summary>
    public class LeftMarginConverter : IMultiValueConverter
    {

        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Application.Current == null ||
                Application.Current.GetType() != typeof(App))
                return false;
            double value = (float)values[0];
            double range = (float)values[1];
            double width = (double)values[2];
            Thickness thick;
            if (value < 0)
            {
                thick = new Thickness(range != 0 ? width / 2 + width / 2 * (value / range) : 0, 0, width / 2, 0);
            }
            else
            {
                thick = new Thickness(width / 2, 0, width / 2, 0);
            }
            return thick;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// Класс конвертации значения в строку
    /// </summary>
    public class ValueConverter : IMultiValueConverter
    {

        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Application.Current == null ||
                Application.Current.GetType() != typeof(App))
                return false;
            string value = values[0].ToString();
            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }


    /// <summary>
    /// Класс конвертации значения положение текста
    /// </summary>
    public class LableAlignmentConverter : IMultiValueConverter
    {

        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Application.Current == null ||
                Application.Current.GetType() != typeof(App))
                return false;
            HorizontalAlignment type = HorizontalAlignment.Center;
            if ((float)values[0] >= 0)
            {
                type = HorizontalAlignment.Right;
            }
            else
            {
                type = HorizontalAlignment.Left;
            }
            return type;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
