using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.MefExtensions
{
    [Export( "1DE5805C-F907-4423-8456-C861AE53A4F9", typeof( IOsRecognizer ) )]
    public class RegistryRecognizer 
        : global::XElement.DotNet.System.Environment.RegistryRecognizer { }
}
