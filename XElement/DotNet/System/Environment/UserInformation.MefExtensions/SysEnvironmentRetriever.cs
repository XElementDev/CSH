using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    [Export( typeof( IUserInfoRetrieverInt ) )]
    internal class SysEnvironmentRetriever : 
        global::XElement.DotNet.System.Environment.UserInformation.SysEnvironmentRetriever { }
#endregion
}
