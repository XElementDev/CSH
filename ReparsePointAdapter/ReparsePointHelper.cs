using ReparsePoints;

namespace XElement.CloudSyncHelper.ReparsePointAdapter
{
    //  --> Wraps code taken from: http://www.codeproject.com/Articles/21202/Reparse-Points-in-Vista
    //      Last visited: 2015-08-18
    public /*static*/ class ReparsePointHelper
    {
        public string GetTarget( string path )
        {
            return new ReparsePoint( path ).Target;
        }
    }
}
