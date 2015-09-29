using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.MefExtensions
{
    [Export( typeof( IOsRecognizer ))]
    public class WmiRecognizer 
        : global::XElement.DotNet.System.Environment.WmiRecognizer { }
}
