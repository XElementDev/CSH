﻿using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class LinkParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }

        public ILinkInfo LinkInfo { get; set; }

        public IPathVariables PathVariables { get; set; }
    }
#endregion
}
