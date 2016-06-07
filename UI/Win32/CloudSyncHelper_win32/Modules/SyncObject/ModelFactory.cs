using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    [Export( typeof( IFactory<SyncObjectModel, ProgramInfoViewModel> ) )]
    internal class ModelFactory : IFactory<SyncObjectModel, ProgramInfoViewModel>
    {
        [ImportingConstructor]
        private ModelFactory() { }

        private InstalledProgramViewModel GetBestMatchingInstalledProgramVM( ProgramInfoViewModel programInfoVM )
        {
            return this._installedProgramsModel.InstalledProgramVMs.FirstOrDefault( p =>
            {
                return Regex.IsMatch( p.DisplayName, programInfoVM.TechnicalNameMatcher );
            } );
        }

        public SyncObjectModel Get( ProgramInfoViewModel programInfoVM )
        {
            SyncObjectModel result = null;

            var installedProgramVM = this.GetBestMatchingInstalledProgramVM( programInfoVM );
            if ( installedProgramVM == default( InstalledProgramViewModel ) )
            {
                result = new SyncObjectModel( programInfoVM,
                                              this._semiautoSyncModelFactory );
            }
            else
            {
                result = new SyncObjectModel( programInfoVM, 
                                              installedProgramVM, 
                                              this._semiautoSyncModelFactory );
            }

            return result;
        }

        [Import]
        private InstalledProgramsModel _installedProgramsModel = null;

        [Import]
        private IFactory<SemiautomaticSync.Model, SemiautomaticSync.IModelParameters> _semiautoSyncModelFactory = null;
    }
#endregion
}
