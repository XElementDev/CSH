using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SegaAllStars2013 : AbstractGameInfo
    {
        [ImportingConstructor]
        public SegaAllStars2013() : base( "0074BFE1-1954-4A3B-9ACE-A313F9C868FE" )
        {
            this.ApplicationName = "Sonic & All-Stars Racing Transformed";
            this.FolderName = "Sega All-Stars 2013 [Sonic _ All-Stars Racing Transformed]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
