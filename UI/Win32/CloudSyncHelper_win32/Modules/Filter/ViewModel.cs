using System.ComponentModel;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.Filter
{
#region not unit-tested
    [Export]
    public class ViewModel : ViewModelBase, 
                             INotifyPropertyChanged, 
                             IPartImportsSatisfiedNotification
    {
        public string CurrentFilter
        {
            get { return this._filterModel.Filter; }
            set
            {
                this._filterModel.Filter = value;
                this.RaisePropertyChanged( nameof( this.CurrentFilter ) );
            }
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._filterModel.PropertyChanged += ( s, e ) =>
            {
                this.RaisePropertyChanged( "CurrentFilter" );
            };
        }

        [Import]
        private FilterModel _filterModel = null;
    }
#endregion
}
