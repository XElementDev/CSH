namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
    public interface ILink
    {
        bool IsLinked { get; }

        string LinkPath { get; }

        string TargetPath { get; }
    }
}
