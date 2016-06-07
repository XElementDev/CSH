namespace XElement.CloudSyncHelper.Logic
{
    public interface ILink
    {
        bool IsLinked { get; }

        string LinkPath { get; }

        string TargetPath { get; }
    }
}
