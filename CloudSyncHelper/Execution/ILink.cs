namespace XElement.CloudSyncHelper
{
    public interface ILink : IDoUndoCommand
    {
        string Link { get; }

        string StandardOutput { get; }

        string Target { get; }
    }
}
