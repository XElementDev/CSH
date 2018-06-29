using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BatmanArkhamCity : AbstractGameInfo
    {
        [ImportingConstructor]
        public BatmanArkhamCity() : base( "62CC3CFD-3ADC-4B9D-85FD-5D2774823C89" )
        {
            this.ApplicationName = "Batman: Arkham City";
            this.FolderName = "Batman Arkham 2011 [Batman_ Arkham City]";
            this.TechnicalNameMatcher = "Batman: Arkham City GOTY";   // TODO: 2017-04-14, Ian: What about this expression? "Batman: Arkham City( GOTY)?"
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
