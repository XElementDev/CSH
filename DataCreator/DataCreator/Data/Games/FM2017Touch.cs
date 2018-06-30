using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FootballManager2017Touch : AbstractGameInfo
    {
        [ImportingConstructor]
        public FootballManager2017Touch() : base( "9FD826FC-7AEB-4CD3-AEF6-B670D6DFC826" )
        {
            this.ApplicationName = "Football Manager Touch 2017";
            this.FolderName = "FM 2016 [Football Manager Touch 2017]";
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
