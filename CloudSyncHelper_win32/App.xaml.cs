using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    public partial class App : Application
    {
        public App()
        {
            this.InitializeMef();

            this.MainWindow = new MainWindow { DataContext = this._mainVM };
            this.MainWindow.Show();

            this._mainVM.OnMefImportsSatisfied();
        }

        private void InitializeMef()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add( new AssemblyCatalog( typeof( App ).Assembly ) );

            var container = new CompositionContainer( catalog );

            container.ComposeExportedValue<IEventAggregator>( new EventAggregator() );
            container.ComposeParts( this );
        }

        [Import]
        private MainViewModel _mainVM = null;
    }
#endregion
}
