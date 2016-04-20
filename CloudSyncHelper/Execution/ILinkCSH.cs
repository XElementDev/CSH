using System;
using XElement.DesignPatterns.BehavioralPatterns.Command;

namespace XElement.CloudSyncHelper
{
    [Obsolete( "Use [...].Logic.ILink interface instead.", error: false )]
    public interface ILinkCSH : IDoUndoCommand
    {
        bool IsInCloud { get; }

        bool IsLinked { get; }

        string LinkPath { get; }

        void MoveToCloud();

        string TargetPath { get; }
    }
}
