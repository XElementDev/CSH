﻿namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( FullyAutomaticSync.Model fullyAutomaticSyncModel )
        {
            this.Model = fullyAutomaticSyncModel;
        }

        public FullyAutomaticSync.Model Model { get; private set; }
    }
#endregion
}
