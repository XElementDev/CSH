using Microsoft.Win32;

namespace XElement.CloudSyncHelper.InstalledPrograms
{
#region not unit-tested
    internal static class Extensions
    {
        public static T GetValueOrDefault<T>( this RegistryKey registryKey, string name )
        {
            T value = default( T );

            try
            {
                value = (T)registryKey.GetValue( name );
            }
            catch { }

            return value;
        }
    }
#endregion
}
