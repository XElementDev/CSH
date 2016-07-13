using System.Windows.Controls;
using System.Windows.Markup;

#region not unit-tested
//  --> https://social.msdn.microsoft.com/Forums/vstudio/en-US/6b1023c3-30d3-44db-9cac-b5a0b29f204f/multiple-assembies-under-one-namespace?forum=wpf
//      Last visited: 2016-06-13
[assembly: XmlnsDefinition( "https://github.com/XElementSoftware/CloudSyncHelper/tree/master/UI/Win32/Modules",
    "XElement.CloudSyncHelper.UI.Win32.Modules" )]
namespace XElement.CloudSyncHelper.UI.Win32.Modules
{
    public partial class UserProfileUC : UserControl
    {
        public UserProfileUC()
        {
            InitializeComponent();
        }
    }
}
#endregion
