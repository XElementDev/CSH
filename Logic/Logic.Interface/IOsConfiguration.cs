using XElement.DesignPatterns.BehavioralPatterns.Command;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfiguration : IDoUndoCommand
    {
        bool IsInCloud { get; }

        bool IsLinked { get; }

        void Link();

        void Unlink();
    }
}
