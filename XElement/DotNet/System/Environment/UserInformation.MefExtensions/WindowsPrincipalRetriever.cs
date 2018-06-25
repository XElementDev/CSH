using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    [Export( typeof( IRoleInformation ) )]
    internal class WindowsPrincipalRetriever : 
        global::XElement.DotNet.System.Environment.UserInformation.WindowsPrincipalRetriever { }
#endregion
}
