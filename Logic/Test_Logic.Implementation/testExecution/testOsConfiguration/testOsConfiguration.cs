using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telerik.JustMock;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;
using XElement.CloudSyncHelper.Logic.Execution.Link;

namespace XElement.CloudSyncHelper.Logic
{
    [TestClass]
    public class testOsConfiguration
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            this.ResetParameters();
        }


        [TestCleanup()]
        public void TestCleanup()
        {
            this.ResetParameters();
        }



        [TestMethod]
        public void testOsConfiguration_ImplementsIOsConfiguration()
        {
            this._linkInfos = new List<ILinkInfo>();

            this.InitializeTarget();

            Assert.IsInstanceOfType( this._target, typeof( IOsConfiguration ) );
        }

        [TestMethod]
        public void testOsConfiguration_ImplementsIOsConfigurationInt()
        {
            this._linkInfos = new List<ILinkInfo>();

            this.InitializeTarget();

            Assert.IsInstanceOfType( this._target, typeof( IOsConfigurationInt ) );
        }


        [TestMethod]
        public void testOsConfiguration_IsLinkedRatio_0Links()
        {
            this._linkInfos = new List<ILinkInfo>();
            this.InitializeTarget();

            var actual = this._target.IsLinkedRatio;

            Assert.AreEqual( 0F, actual );
        }

        [TestMethod]
        public void testOsConfiguration_IsLinkedRatio_1LinkedLink()
        {
            this.AddMockedLinkInfos( amount: 1 );
            var isLinkedSequence = new List<bool> { true };
            this._linkFactoryMock = this.CreateLinkFactoryMockFollowing( isLinkedSequence );
            this.InitializeTarget();

            var actual = this._target.IsLinkedRatio;

            Assert.AreEqual( 1F, actual );
        }

        [TestMethod]
        public void testOsConfiguration_IsLinkedRatio_2Links1Linked()
        {
            this.AddMockedLinkInfos( amount: 2 );
            var isLinkedSequence = new List<bool> { false, true };
            this._linkFactoryMock = this.CreateLinkFactoryMockFollowing( isLinkedSequence );
            this.InitializeTarget();

            var actual = this._target.IsLinkedRatio;

            Assert.AreEqual( .5F, actual );
        }



        private void AddMockedLinkInfos( int amount )
        {
            for ( int i = 0 ; i < amount ; ++i )
            {
                var mock = Mock.Create<ILinkInfo>( Behavior.Strict );
                this._linkInfos.Add( mock );
            }
        }


        private ILinkFactory CreateLinkFactoryMockFollowing( IList<bool> isLinkedSequence )
        {
            var linkFactoryMock = Mock.Create<ILinkFactory>( Behavior.Strict );

            for ( int i = 0 ; i < isLinkedSequence.Count ; ++i )
            {
                var linkMock = Mock.Create<ILinkInt>( Behavior.Strict );
                Mock.Arrange( () => linkMock.IsLinked ).Returns( isLinkedSequence[i] );
                Mock.Arrange( () => linkFactoryMock.Get( Arg.IsAny<IApplicationInfo>(), 
                    this._linkInfos[i], Arg.IsAny<PathVariablesDTO>() ) ).Returns( linkMock );
            }

            return linkFactoryMock;
        }


        private void InitializeTarget()
        {
            var osCfgInfoMock = Mock.Create<IOsConfigurationInfo>();
            Mock.Arrange( () => osCfgInfoMock.Links ).Returns( this._linkInfos );

            var parametersDTO = new OsConfigurationParametersDTO
            {
                ApplicationInfo = Mock.Create<IApplicationInfo>( Behavior.Strict ), 
                OsConfigurationInfo = osCfgInfoMock, 
                PathVariablesDTO = Mock.Create<PathVariablesDTO>( Behavior.Strict )
            };
            var dependenciesDTO = new OsConfigurationDependenciesDTO
            {
                LinkFactory = this._linkFactoryMock
            };
            this._target = new OsConfiguration( parametersDTO, dependenciesDTO );
        }


        private void ResetParameters()
        {
            this._linkFactoryMock = Mock.Create<ILinkFactory>( Behavior.Strict );
            this._linkInfos = new List<ILinkInfo>();
            this._target = null;
        }


        private ILinkFactory _linkFactoryMock;
        private List<ILinkInfo> _linkInfos;
        private IOsConfigurationInt _target;
    }
}
