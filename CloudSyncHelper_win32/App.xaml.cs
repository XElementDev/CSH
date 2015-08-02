using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    public partial class App : Application
    {
        public App()
        {
            var mainVM = new MainViewModel();
            this.MainWindow = new MainWindow { DataContext = mainVM };

            this.MainWindow.Show();
        }
    }
#endregion
}
