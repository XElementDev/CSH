using System;
using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
    public class ExecutionLogic
    {
        public ExecutionLogic( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }

        public IReadOnlyList<ILinkInfo> Config
        {
            get
            {
                var suitableConfig = OsIdHelper.GetSuitableConfig( this._programInfo.OsConfigs );
                return suitableConfig;
            }
        }

        public bool HasSuitableConfig()
        {
            var isThereAConfigForThisOs = this.Config != null;
            return isThereAConfigForThisOs;
        }

        public void Link()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void Unlink()
        {
            // TODO
            throw new NotImplementedException();
        }

        private IProgramInfo _programInfo;
    }
}
