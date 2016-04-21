using System;
using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( OsConfiguration.Model model )
        {
            this.Model = model;
            this.InitializePathMap();
        }

        private void InitializePathMap()
        {
            var pathMap = new List<Tuple<string, string>>();

            foreach ( var link in this.Model.Links )
            {
                var twoTuple = new Tuple<string, string>( link.LinkPath, link.TargetPath );
                pathMap.Add( twoTuple );
            }

            this.PathMap = pathMap;
        }

        public Model Model { get; private set; }

        public IEnumerable<Tuple<string, string>> PathMap { get; private set; }
    }
#endregion
}
