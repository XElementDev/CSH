using XElement.DesignPatterns.BehavioralPatterns.Command;

namespace XElement.CloudSyncHelper.Logic.Execution
{
    internal interface ILink : IDoUndoCommand
    {
        bool IsInCloud { get; }

        bool IsLinked { get; }
    }
}
