using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
#region not unit-tested
    public partial class FlaticonCreditUC : UserControl
    {
        public FlaticonCreditUC()
        {
            InitializeComponent();
        }

        public string AuthorName
        {
            get { return (string)GetValue( AuthorNameProperty ); }
            set { SetValue( AuthorNameProperty, value ); }
        }
        public static readonly DependencyProperty AuthorNameProperty =
            DependencyProperty.Register( "AuthorName", typeof( string ),
                                         typeof( FlaticonCreditUC ),
                                         new FrameworkPropertyMetadata( String.Empty ) );

        public Uri AuthorUri
        {
            get { return (Uri)GetValue( AuthorUriProperty ); }
            set { SetValue( AuthorUriProperty, value ); }
        }
        public static readonly DependencyProperty AuthorUriProperty = 
            DependencyProperty.Register( "AuthorUri", typeof( Uri ),
                                         typeof( FlaticonCreditUC ),
                                         new FrameworkPropertyMetadata( null ) );

        private void Hyperlink_RequestNavigate( object sender, RequestNavigateEventArgs e )
        {
            //  --> 2016-01-25: https://stackoverflow.com/questions/10238694/example-using-hyperlink-in-wpf
            Process.Start( new ProcessStartInfo( e.Uri.AbsoluteUri ) );
            e.Handled = true;
        }

        public ImageSource IconImageSource
        {
            get { return (ImageSource)GetValue( IconImageSourceProperty ); }
            set { SetValue( IconImageSourceProperty, value ); }
        }
        public static readonly DependencyProperty IconImageSourceProperty = 
            DependencyProperty.Register( "IconImageSource", typeof( ImageSource ),
                                         typeof( FlaticonCreditUC ),
                                         new FrameworkPropertyMetadata( null ) );
    }
#endregion
}
