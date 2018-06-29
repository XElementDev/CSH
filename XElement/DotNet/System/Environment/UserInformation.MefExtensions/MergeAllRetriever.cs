using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    [Export( typeof( IUserInfoRetriever ) )]
    internal class MergeAllRetriever : IUserInfoRetriever, IPartImportsSatisfiedNotification
    {
        public MergeAllRetriever()
        {
            return;
        }


        public IUserInformation /*IUserInfoRetriever.*/Get() { return this._userInformation; }


        public IUserInformation GetCurrentUser()
        {
            var merged = new UserInformation();

            foreach ( var userInfo in this._orderedUserInfos )
            {
                if ( merged.FullName == null | merged.FullName == String.Empty )
                    merged.FullName = userInfo.FullName;
                if ( merged.Role == null )
                    merged.Role = userInfo.Role;
                if ( merged.TechnicalName == null | merged.TechnicalName == String.Empty )
                    merged.TechnicalName = userInfo.TechnicalName;
            }

            return merged;
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.OrderUserInfos();
            this._userInformation = this.GetCurrentUser();
        }


        private void OrderUserInfos()
        {
            var comparer = new ReliabilityComparer();
            var userInfos = this._userInfoRetrievers.Select( r => r.Get() ).ToList();
            var orderedUserInfos = userInfos.OrderBy( svc => svc, comparer ).ToList();
            this._orderedUserInfos = orderedUserInfos;
        }


        private IEnumerable<IUserInformation> _orderedUserInfos;

        [ImportMany( typeof( IUserInfoRetrieverInt ) )]
        private IEnumerable<IUserInfoRetriever> _userInfoRetrievers = null;

        private IUserInformation _userInformation;
    }


    internal class ReliabilityComparer : IComparer<IUserInformation>
    {
        public int Compare( IUserInformation x, IUserInformation y )
        {
            var indexOfX = _reliabilityOrder.IndexOf( x.GetType() );
            var indexOfY = _reliabilityOrder.IndexOf( y.GetType() );
            return indexOfX.CompareTo( indexOfY );
        }


        /// <summary>
        /// In order of ascending reliability, i.e. most reliable comes last.
        /// (Such that information of less reliable retrievers can simply be overwritten.)
        /// </summary>
        private static IList<Type> _reliabilityOrder = new List<Type>
        {
            typeof( SysEnvironmentRetriever ), 
            typeof( WindowsPrincipalRetriever ), 
            typeof( DirectoryEntryRetriever )
        };
    }
    #endregion
}
