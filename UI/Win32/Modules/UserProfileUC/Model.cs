namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.FullName = parameters.FullName;
            this.IsAdministrator = parameters.IsAdministrator;
        }


        public string FullName { get; private set; }


        public bool? IsAdministrator { get; private set; }
    }
#endregion
}
