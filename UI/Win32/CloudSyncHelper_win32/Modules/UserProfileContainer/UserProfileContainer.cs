using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment.UserInformation;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
#region not unit-tested
    [Export]
    public class UserProfileContainer : NotifyPropertyChanged, IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private UserProfileContainer()
        {
            this.IsLoaded = false;
        }


        private void InitializeAsync()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += ( s, e ) =>
            {
                this.InitializeUserProfileModel();
            };
            bw.RunWorkerCompleted += ( s, e ) =>
            {
                this.InitializeUserProfileVM();
                this.IsLoaded = true;
            };
            bw.RunWorkerAsync();
        }


        private void InitializeUserProfileModel()
        {
            var currentUser = this._lazyUserInfo.Value;
            var parameters = new UserProfile.ModelParametersDTO
            {
                FullName = currentUser.FullName, 
                IsAdministrator = currentUser.Role == Role.Administrator, 
                TechnicalName = currentUser.TechnicalName
            };
            this._userProfileModel = new UserProfile.Model( parameters );
        }


        private void InitializeUserProfileVM()
        {
            this.UserProfileVM = new UserProfile.ViewModel( this._userProfileModel );
        }


        private bool _isLoaded;
        public bool IsLoaded
        {
            get { return this._isLoaded; }
            private set
            {
                this._isLoaded = value;
                this.RaisePropertyChanged( nameof( this.IsLoaded ) );
                this.RaisePropertyChanged( nameof( this.UserProfileVM ) );
            }
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.InitializeAsync();
        }


        public UserProfile.ViewModel UserProfileVM { get; private set; }


        //  --> https://stackoverflow.com/questions/3108820/lazy-load-with-mef
        [Import( typeof( IUserInformation ), AllowDefault = true, AllowRecomposition = true )]
        private Lazy<IUserInformation> _lazyUserInfo = null;


        private UserProfile.Model _userProfileModel;
    }
#endregion
}
