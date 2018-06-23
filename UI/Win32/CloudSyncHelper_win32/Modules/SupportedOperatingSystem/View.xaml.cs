using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
    #region not unit-tested
    public partial class SupportedOperatingSystemView : UserControl
    {
        public SupportedOperatingSystemView()
        {
            InitializeComponent();
        }


        public bool IsOsSupported
        {
            get { return (bool)GetValue( IsOsSupportedProperty ); }
            set { SetValue( IsOsSupportedProperty, value ); }
        }
        public static readonly DependencyProperty IsOsSupportedProperty =
            DependencyProperty.Register( "IsOsSupported", typeof( bool ),
                                         typeof( SupportedOperatingSystemView ),
                                         new FrameworkPropertyMetadata( false ) );


        public ImageSource OsImageSource
        {
            get { return (ImageSource)GetValue( OsImageSourceProperty ); }
            set { SetValue( OsImageSourceProperty, value ); }
        }
        public static readonly DependencyProperty OsImageSourceProperty =
            DependencyProperty.Register( "OsImageSource", typeof( ImageSource ),
                                         typeof( SupportedOperatingSystemView ),
                                         new FrameworkPropertyMetadata( null ) );


        public string OsName
        {
            get { return (string)GetValue( OsNameProperty ); }
            set { SetValue( OsNameProperty, value ); }
        }
        public static readonly DependencyProperty OsNameProperty =
            DependencyProperty.Register( "OsName", typeof( string ),
                                         typeof( SupportedOperatingSystemView ),
                                         new FrameworkPropertyMetadata( String.Empty ) );
    }
#endregion
}
