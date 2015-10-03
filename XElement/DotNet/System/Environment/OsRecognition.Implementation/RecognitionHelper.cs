namespace XElement.DotNet.System.Environment
{
    internal static class RecognitionHelper
    {
        public static OsId? GetOsIdByString( string version )
        {
            //if      ( version.Major == 6 && version.Minor == 0 )  return OsId.WinVista;
            //else if ( version.Minor == 6 && version.Minor == 1 )  return OsId.Win7;
            //else if ( version.Major == 6 && version.Minor == 2 )  return OsId.Win8;
            if      ( version.StartsWith( "6.3" ) ) return OsId.Win81;
            else if ( version.StartsWith( "10.0" ) ) return OsId.Win10;
            else return null;
        }
    }
}
