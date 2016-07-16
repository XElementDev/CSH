using System.Windows;
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


        public Thickness ButtonOffset
        {
            get
            {
                var left = 0D;
                var top = 0D;
                var right = this.ButtonOffsetFromRight;
                var bottom = 0D;
                return new Thickness( left, top, right, bottom );
            }
        }


        public double ButtonOffsetFromRight
        {
            get { return (double)GetValue( ButtonOffsetFromRightProperty ); }
            set
            {
                SetValue( ButtonOffsetFromRightProperty, value );
            }
        }

        public static readonly DependencyProperty ButtonOffsetFromRightProperty = 
            DependencyProperty.Register( "ButtonOffsetFromRight", typeof( double ), 
                                         typeof( UserProfileUC ), 
                                         new FrameworkPropertyMetadata( BUTTON_OFFSET_FROM_RIGHT_DEFAULT_VALUE ) );

        private const double BUTTON_OFFSET_FROM_RIGHT_DEFAULT_VALUE = 0D;
    }
}
#endregion
