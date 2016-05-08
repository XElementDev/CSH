using XElement.DesignPatterns.BehavioralPatterns.Command;

namespace XElement.CloudSyncHelper.Logic.Execution
{
    internal interface ILinkInt : IDoUndoCommand, ILink
    {
        bool IsInCloud { get; }


        void MoveToCloud();
    }
}
