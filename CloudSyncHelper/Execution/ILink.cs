namespace XElement.CloudSyncHelper
{
    public interface ILink : IDoUndoCommand
    {
        bool IsInCloud { get; }

        bool IsLinked { get; }

        string Link { get; }

        string StandardOutput { get; }

        string Target { get; }
    }
}
