using System;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            this.Initialize();
        }


        public string DisplayName { get; private set; }


        private void Initialize()
        {
            var fullName = (this.Model.FullName == String.Empty ? null : this.Model.FullName);
            this.DisplayName = fullName ?? this.Model.TechnicalName;
        }


        public Model Model { get; private set; }
    }
#endregion
}
