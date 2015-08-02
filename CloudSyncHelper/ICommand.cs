
namespace XElement.CloudSyncHelper
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }
}
