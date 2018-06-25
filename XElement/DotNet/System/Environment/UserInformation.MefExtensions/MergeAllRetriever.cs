using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    [Export( typeof( IUserInformation ) )]
    internal class MergeAllRetriever : IUserInformation, IPartImportsSatisfiedNotification
    {
        public MergeAllRetriever()
        {
            this.FullName = null;
            this.Role = null;
            this.TechnicalName = null;
        }


        public string /*IUserInformation.*/FullName { get; private set; }


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
            this.SetProperties();
        }


        private void OrderUserInfos()
        {
            var comparer = new ReliabilityComparer();
            var orderedInfos = this._userInfos.OrderBy( svc => svc, comparer ).ToList();
            this._orderedUserInfos = orderedInfos;
        }


        public Role? /*IUserInformation.*/Role { get; private set; }


        private void SetProperties()
        {
            var userInfo = this.GetCurrentUser();
            this.FullName = userInfo.FullName;
            this.Role = userInfo.Role;
            this.TechnicalName = userInfo.TechnicalName;
        }


        public string /*IUserInformation.*/TechnicalName { get; private set; }


        private IEnumerable<IUserInformation> _orderedUserInfos;


        [ImportMany( typeof( IUserInformationInt ) )]
        private IEnumerable<IUserInformation> _userInfos = null;
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
