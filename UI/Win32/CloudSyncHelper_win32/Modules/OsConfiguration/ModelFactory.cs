using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    [Export( typeof( IFactory<OsConfiguration.Model, IEnumerable<ILink>> ) )]
    internal class ModelFactory : IFactory<OsConfiguration.Model, IEnumerable<ILink>>
    {
        public Model Get( IEnumerable<ILink> links )
        {
            var modelCtorParams = new ModelCtorParams { Links = links };
            var model = new Model( modelCtorParams );
            return model;
        }

        private class ModelCtorParams : IModelConstructorParameters
        {
            public IEnumerable<ILink> Links { get; set; }
        }
    }
#endregion
}
