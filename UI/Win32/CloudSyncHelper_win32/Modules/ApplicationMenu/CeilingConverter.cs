using System;
using System.Globalization;
using System.Windows.Data;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu
{
#region not unit-tested
    internal class CeilingConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            double @double = (double)value;
            var ceiledValue = Math.Ceiling( @double );
            return ceiledValue;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
#endregion
}
