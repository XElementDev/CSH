using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
#region not unit-tested
    public partial class AboutUC : UserControl
    {
        public AboutUC()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate( object sender, RequestNavigateEventArgs e )
        {
            //  --> 2016-01-25: https://stackoverflow.com/questions/10238694/example-using-hyperlink-in-wpf
            Process.Start( new ProcessStartInfo( e.Uri.AbsoluteUri ) );
            e.Handled = true;
        }
    }
#endregion
}
