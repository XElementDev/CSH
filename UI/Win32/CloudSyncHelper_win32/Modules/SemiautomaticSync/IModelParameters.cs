﻿using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
    public interface IModelParameters
    {
        bool IsInstalled { get; }

        ProgramInfoViewModel ProgramInfoVM { get; }
    }
}
