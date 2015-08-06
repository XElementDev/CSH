using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using XElement.CloudSyncHelper.UI.Win32.Events;

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

            this._eventAggregator.GetEvent<MefImportsSatisfied>().Publish();
        }

        private void InitializeMef()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add( new AssemblyCatalog( typeof( App ).Assembly ) );

            var container = new CompositionContainer( catalog );

            container.ComposeExportedValue<IEventAggregator>( new EventAggregator() );
            container.ComposeParts( this );
        }

#pragma warning disable 0649
        [Import]
        private IEventAggregator _eventAggregator;

        [Import]
        private MainViewModel _mainVM;
#pragma warning restore 0649
    }
#endregion
}
