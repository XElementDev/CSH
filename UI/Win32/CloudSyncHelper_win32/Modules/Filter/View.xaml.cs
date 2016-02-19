using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
#region not unit-tested
    public partial class FilterUC : UserControl
    {
        public FilterUC()
        {
            InitializeComponent();
        }

        //  --> Based on: https://stackoverflow.com/questions/3109080/focus-on-textbox-when-usercontrol-change-visibility
        //      Last visited: 2016-02-19
        private void UserControl_IsVisibleChanged( object sender, 
                                                   DependencyPropertyChangedEventArgs e )
        {
            if ( this.IsVisible )
            {
                this.Dispatcher.BeginInvoke( (Action)delegate { this._filterTextBox.Focus(); },
                                             DispatcherPriority.Render );
            }
        }
    }
#endregion
}
