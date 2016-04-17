using System;
using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( OsConfiguration.Model model )
        {
            this.InitializePathMap( model.Links );
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
