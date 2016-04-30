using System.Windows;
using System.Windows.Controls;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
#region not unit-tested
    public partial class SemiautomaticSyncUC : UserControl
    {
        public SemiautomaticSyncUC()
        {
            InitializeComponent();
        }

        private void ContentGrid_Loaded( object sender, RoutedEventArgs e )
        {
            this._pathMapContainer.MaxHeight = this._contentGrid.ActualHeight - 4;
        }
    }
#endregion
}
