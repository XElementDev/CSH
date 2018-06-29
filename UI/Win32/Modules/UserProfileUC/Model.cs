namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.FullName = parameters.FullName;
            this.IsAdministrator = parameters.IsAdministrator;
            this.TechnicalName = parameters.TechnicalName;
        }


        public string FullName { get; private set; }


        public bool? IsAdministrator { get; private set; }


        public string TechnicalName { get; private set; }
    }
#endregion
}
