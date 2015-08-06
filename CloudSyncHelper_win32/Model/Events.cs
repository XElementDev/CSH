using Microsoft.Practices.Prism.Events;

namespace XElement.CloudSyncHelper.UI.Win32.Events
{
    internal class MefImportsSatisfied : EmptyPresentationEvent { }

    internal class StandardOutputChanged : CompositePresentationEvent<string> { }
}
