namespace XElement.CloudSyncHelper.UI.Win32.Localization
{
#region not unit-tested
    public class LocalizationForXaml
    {
        public Localization Localization
        {
            get
            {
                if ( _localizationSingleton == null )
                {
                    _localizationSingleton = new Localization();
                }
                return _localizationSingleton;
            }
        }

        private static Localization _localizationSingleton;
    }
#endregion
}
