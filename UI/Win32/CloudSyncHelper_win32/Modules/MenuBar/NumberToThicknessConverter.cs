using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar
{
#region not unit-tested
    public class NumberToThicknessConverter : IValueConverter
    {
        public NumberToThicknessConverter()
        {
            this.Negate = false;
            this.ShouldConvertBottom = true;
            this.ShouldConvertLeft = true;
            this.ShouldConvertRight = true;
            this.ShouldConvertTop = true;
        }


        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var valueAsNumber = value as double?;

            if ( !valueAsNumber.HasValue )
                throw new ArgumentException( "This type of argument is not supported." );
            else
                return this.ConvertNumberToThickness( valueAsNumber );
        }

        private Thickness ConvertNumberToThickness( double? valueAsNumber )
        {
            var thickness = new Thickness();
            var number = valueAsNumber.Value;

            if ( this.Negate ) number = (-1) * number;
            if ( this.ShouldConvertLeft ) thickness.Left = number;
            if ( this.ShouldConvertTop ) thickness.Top = number;
            if ( this.ShouldConvertRight ) thickness.Right = number;
            if ( this.ShouldConvertBottom ) thickness.Bottom = number;

            return thickness;
        }


        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }


        public bool Negate { get; set; }


        public bool ShouldConvertBottom { get; set; }


        public bool ShouldConvertLeft { get; set; }


        public bool ShouldConvertRight { get; set; }


        public bool ShouldConvertTop { get; set; }
    }
#endregion
}
