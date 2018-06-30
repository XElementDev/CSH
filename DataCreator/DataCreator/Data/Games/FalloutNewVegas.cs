using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FalloutNewVegas : AbstractGameInfo
    {
        [ImportingConstructor]
        public FalloutNewVegas() : base( "82423A58-05E4-4A40-9086-A49ADD4D7620" )
        {
            this.ApplicationName = "Fallout: New Vegas";
            this.FolderName = "Fallout 2010-2011 [Fallout_ New Vegas]";
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
