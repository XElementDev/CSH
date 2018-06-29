namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
#region not unit-tested
    public class Factory : IFactory
    {
        public Factory( DependenciesDTO dependencies )
        {
            this._dependencies = dependencies;
        }


        public IExecutor Get( ParametersDTO parameters )
        {
            return new Executor( parameters, this._dependencies );
        }


        private DependenciesDTO _dependencies;
    }
#endregion
}
