namespace XElement.CloudSyncHelper
{
    public interface ILink : IDoUndoCommand
    {
        bool IsInCloud { get; }

        bool IsLinked { get; }

        string LinkPath { get; }

        void MoveToCloud();

        string TargetPath { get; }
    }
}
