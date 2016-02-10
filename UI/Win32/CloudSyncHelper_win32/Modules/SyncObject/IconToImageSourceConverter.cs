using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    internal class IconToImageSourceConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            ImageSource imageSource = null;

            var icon = value as Icon;
            if ( icon != null )
            {
                imageSource = CreateImageSourceFromIcon( icon );
            }

            return imageSource;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        //  --> Based on: https://stackoverflow.com/questions/1127647/convert-system-drawing-icon-to-system-media-imagesource
        //  Last accessed: 2016-02-10
        private static ImageSource CreateImageSourceFromIcon( Icon icon )
        {
            var sourceRect = Int32Rect.Empty;
            var sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            return Imaging.CreateBitmapSourceFromHIcon( icon.Handle, sourceRect, sizeOptions );
        }
    }
#endregion
}
