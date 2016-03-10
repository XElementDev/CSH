using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OperatingSystem
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.InitializeIndicators( model.OsId );
            this.InitializeOsName( model.OsId );
        }

        private void InitializeIndicators( OsId osId )
        {
            this.ShowWindows81 = false;
            this.ShowWindows10 = false;

            if ( osId == OsId.Win81 )
            {
                this.ShowWindows81 = true;
            }
            else if ( osId == OsId.Win10 )
            {
                this.ShowWindows10 = true;
            }
        }

        private void InitializeOsName( OsId osId )
        {
            if ( osId == OsId.Win81 )
            {
                this.OsName = "8.1";
            }
            else if ( osId == OsId.Win10 )
            {
                this.OsName = "10";
            }
        }

        public string OsName { get; private set; }

        public bool ShowWindows81 { get; private set; }

        public bool ShowWindows10 { get; private set; }
    }
#endregion
}
