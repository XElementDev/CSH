using System.ComponentModel;
using System.ComponentModel.Composition;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class FilterModel : NotifyPropertyChanged, 
                               INotifyPropertyChanged
    {
        private string _filter;
        public string Filter
        {
            get { return this._filter; }
            set
            {
                this._filter = value;
                this.RaisePropertyChanged( nameof( this.Filter ) );
            }
        }
    }
#endregion
}
