namespace XElement.CloudSyncHelper
{
    public interface ILink : IDoUndoCommand
    {
        bool IsInCloud { get; }

        string Link { get; }

        string StandardOutput { get; }

        string Target { get; }
    }
}
