using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle( "CloudSyncHelper_win32" )]
[assembly: AssemblyDescription( "" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct( "Cloud Sync Helper" )]
[assembly: AssemblyCopyright( "Copyright © XElement Software 2015-2016" )]
[assembly: AssemblyTrademark( "" )]
[assembly: AssemblyCulture( "" )]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page, 
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page, 
                                              // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion( "0.3.0.500" )]
[assembly: AssemblyFileVersion( "0.3.0.500" )]

#if DEBUG
[assembly: InternalsVisibleTo( "Test_XElement.CloudSyncHelper.UI.Win32" )]

//  --> http://www.telerik.com/help/justmock/basic-usage-mock-internal-types-via-proxy.html
[assembly: InternalsVisibleTo( "Telerik.JustMock, PublicKey=" +
    "0024000004800000940000000602000000240000525341310004000001000100098b1434e598c6" +
    "56b22eb59000b0bf73310cb8488a6b63db1d35457f2f939f927414921a769821f371c31a8c1d4b" +
    "73f8e934e2a0769de4d874e0a517d3d7b9c36cd0ffcea2142f60974c6eb00801de4543ef7e93f7" +
    "9687b040d967bb6bd55ca093711b013967a096d524a9cadf94e3b748ebdae7947ea6de6622eabf" +
    "6548448e" )]
#endif
