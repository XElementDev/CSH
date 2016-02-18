using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    internal class StringToImageSourceConverter : IValueConverter
    {
        //  --> Based on: https://stackoverflow.com/questions/5399601/imagesourceconverter-error-for-source-null
        //      Last visited: 2016-02-18
        public object Convert( object value, Type targetType, 
                               object parameter, CultureInfo culture )
        {
            return value ?? DependencyProperty.UnsetValue;
        }

        public object ConvertBack( object value, Type targetType, 
                                   object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
#endregion
}
