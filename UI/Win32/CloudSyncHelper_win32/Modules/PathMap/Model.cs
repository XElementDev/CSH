using System;
using System.Collections.Generic;
using XElement.CloudSyncHelper.Logic.Execution.Link;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.PathMap
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO @params )
        {
            this.InitializePathMap( @params.Links );
        }

        private void InitializePathMap( IEnumerable<ILink> links )
        {
            var pathMap = new List<Tuple<string, string>>();

            foreach ( var link in links )
            {
                var twoTuple = new Tuple<string, string>( link.LinkPath, link.TargetPath );
                pathMap.Add( twoTuple );
            }

            this.PathMap = pathMap;
        }

        public IEnumerable<Tuple<string, string>> PathMap { get; private set; }
    }
#endregion
}
