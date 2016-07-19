using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    [Export( typeof( IUserInformationService ) )]
    internal class MergeAllRetriever : IUserInformationService, IPartImportsSatisfiedNotification
    {
        public IUserInformation CurrentUser
        {
            get
            {
                var merged = new UserInformation();

                var userInfos = this.UserInformations;
                foreach ( var userInfo in userInfos )
                {
                    if ( merged.FullName == null | merged.FullName == String.Empty )
                        merged.FullName = userInfo.FullName;
                    if ( merged.Role == null )
                        merged.Role = userInfo.Role;
                }

                return merged;
            }
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var comparer = new ReliabilityComparer();
            var orderedSvcs = this._userInfoServices.OrderBy( svc => svc, comparer ).ToList();
            this._orderedUserInfoServices = orderedSvcs;
        }


        private IEnumerable<IUserInformation> UserInformations
        {
            get
            {
                var userInfos = this._orderedUserInfoServices.Select( svc => svc.CurrentUser )
                    .ToList();
                return userInfos;
            }
        }


        private IEnumerable<IUserInformationService> _orderedUserInfoServices;


        [ImportMany( typeof( IUserInformationServiceInt ) )]
        private IEnumerable<IUserInformationService> _userInfoServices = null;
    }


    internal class ReliabilityComparer : IComparer<IUserInformationService>
    {
        public int Compare( IUserInformationService x, IUserInformationService y )
        {
            var indexOfX = _reliabilityOrder.IndexOf( x.GetType() );
            var indexOfY = _reliabilityOrder.IndexOf( y.GetType() );
            return indexOfX.CompareTo( indexOfY );
        }


        //
        // Summary:
        //     In order of ascending reliability, i.e. most reliable comes last. (Such that information of less reliable retrievers can simply be overwritten.)
        private static IList<Type> _reliabilityOrder = new List<Type>
        {
            typeof( SysEnvironmentRetriever ), 
            typeof( WindowsPrincipalRetriever ), 
            typeof( DirectoryEntryRetriever )
        };
    }
    #endregion
}
