namespace XElement.CloudSyncHelper
{
    public interface IDoUndoCommand
    {
        void Do();
        void Undo();
    }
}
