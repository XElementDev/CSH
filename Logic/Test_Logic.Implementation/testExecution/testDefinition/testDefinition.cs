using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;
using XElement.DotNet.System.Environment;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.Logic
{
    [TestClass]
    public class testDefinition
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
        public void testDefinition_ImplementsIDefinition()
        {
            var appInfo = Mock.Create<IApplicationInfo>();
            Mock.Arrange( () => appInfo.DefinitionInfo.OsConfigs )
                .Returns( () => new List<IOsConfigurationInfo>() );
            this._appInfo = appInfo;

            this.InitializeTarget();

            Assert.IsInstanceOfType( this._target, typeof( IDefinition ) );
        }


        [TestMethod]
        public void testDefinition_BestFittingOsConfigurationInfo_NoFullfilledConfig()
        {
            Mock.Arrange( () => this._osFilterMock.GetFilteredOsConfigs( null ) ).IgnoreArguments()
                .Returns( input => input );
            this.AddOsConfigInfos( amount: 2 );
            var isLinkedRatioSequence = new List<float> { .5F, .75F };
            var osCfgFactoryMock = this.CreateOsCfgFactoryMockFollowing( isLinkedRatioSequence );
            this._osConfigFactoryMock = osCfgFactoryMock;
            var expected = this._osConfigInfos[1];
            this.InitializeTarget();

            var actual = this._target.BestFittingOsConfigurationInfo;

            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void testDefinition_BestFittingOsConfigurationInfo_PrefersFulfilledConfig()
        {
            Mock.Arrange( () => this._osFilterMock.GetFilteredOsConfigs( null ) ).IgnoreArguments()
                .Returns( input => input );
            this.AddOsConfigInfos( amount: 2 );
            var isLinkedRatioSequence = new List<float> { .33F, 1F };
            var osCfgFactoryMock = this.CreateOsCfgFactoryMockFollowing( isLinkedRatioSequence );
            this._osConfigFactoryMock = osCfgFactoryMock;
            var expected = this._osConfigInfos[1];
            this.InitializeTarget();

            var actual = this._target.BestFittingOsConfigurationInfo;

            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void testDefinition_BestFittingOsConfigurationInfo_2Configs_PrefersSuitableConfig__RandomValues()
        {
            Add2OsConfigInfosWithDistinctOsIds();
            var expected = XeRandom.RandomTFromArrayOf( this._osConfigInfos.ToArray() );
            var isLinkedRatioSequence = new List<float> { 1F, 1F };
            var osCfgFactoryMock = this.CreateOsCfgFactoryMockFollowing( isLinkedRatioSequence );
            this._osConfigFactoryMock = osCfgFactoryMock;
            Mock.Arrange( () => this._osFilterMock.GetFilteredOsConfigs( null ) ).IgnoreArguments()
                .Returns( new List<IOsConfigurationInfo> { expected } ).MustBeCalled();
            this.InitializeTarget();

            var actual = this._target.BestFittingOsConfigurationInfo;

            Mock.Assert( this._osFilterMock );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void testDefinition_BestFittingOsConfigurationInfo_0Configs()
        {
            Mock.Arrange( () => this._osFilterMock.GetFilteredOsConfigs( null ) ).IgnoreArguments()
                .Returns( input => input );
            this._osConfigInfos.Clear();
            this.InitializeTarget();

            var actual = this._target.BestFittingOsConfigurationInfo;

            Assert.IsNull( actual );
        }


        [TestMethod]
        public void testDefinition_IsInCloud_NoConfig()
        {
            var appInfo = Mock.Create<IApplicationInfo>();
            Mock.Arrange( () => appInfo.DefinitionInfo.OsConfigs )
                .Returns( new List<IOsConfigurationInfo>() );
            this._appInfo = appInfo;
            this.InitializeTarget();

            var isInCloud = this._target.IsInCloud;

            Assert.IsFalse( isInCloud );
        }

        [TestMethod]
        public void testDefinition_IsInCloud_1Config1InCloud()
        {
            this.AddOsConfigInfos( amount: 1 );
            var osConfigMock = CreateOsConfigMockWithIsInCloudSetTo( true );
            var osCfgFactoryMock = CreateOsCfgFactoryMockAlwaysReturning( osConfigMock );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isInCloud = this._target.IsInCloud;

            Assert.IsTrue( isInCloud );
        }

        [TestMethod]
        public void testDefinition_IsInCloud_1Config0InCloud()
        {
            this.AddOsConfigInfos( amount: 1 );
            var osConfigMock = CreateOsConfigMockWithIsInCloudSetTo( false );
            var osCfgFactoryMock = CreateOsCfgFactoryMockAlwaysReturning( osConfigMock );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isInCloud = this._target.IsInCloud;

            Assert.IsFalse( isInCloud );
        }

        [TestMethod]
        public void testDefinition_IsInCloud_2Configs2nd1InCloud()
        {
            this.AddOsConfigInfos( amount: 2 );
            var osConfigMock2 = CreateOsConfigMockWithIsInCloudSetTo( true );
            var osCfgFactoryMock = CreateOsCfgFactoryMockWhere2ndInfoReturns( osConfigMock2 );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isInCloud = this._target.IsInCloud;

            Assert.IsTrue( isInCloud );
        }


        [TestMethod]
        public void testDefinition_IsLinked_NoConfig()
        {
            var appInfo = Mock.Create<IApplicationInfo>();
            Mock.Arrange( () => appInfo.DefinitionInfo.OsConfigs )
                .Returns( new List<IOsConfigurationInfo>() );
            this._appInfo = appInfo;
            this.InitializeTarget();

            var isLinked = this._target.IsLinked;

            Assert.IsFalse( isLinked );
        }

        [TestMethod]
        public void testDefinition_IsLinked_1Config1Linked()
        {
            this.AddOsConfigInfos( amount: 1 );
            var osConfigMock = CreateOsConfigMockWithIsLinkedSetTo( true );
            var osCfgFactoryMock = CreateOsCfgFactoryMockAlwaysReturning( osConfigMock );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isLinked = this._target.IsLinked;

            Assert.IsTrue( isLinked );
        }

        [TestMethod]
        public void testDefinition_IsLinked_1Config0Linked()
        {
            this.AddOsConfigInfos( amount: 1 );
            var osConfigMock = CreateOsConfigMockWithIsLinkedSetTo( false );
            var osCfgFactoryMock = CreateOsCfgFactoryMockAlwaysReturning( osConfigMock );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isLinked = this._target.IsLinked;

            Assert.IsFalse( isLinked );
        }

        [TestMethod]
        public void testDefinition_IsLinked_2Configs2nd1Linked()
        {
            this.AddOsConfigInfos( amount: 2 );
            var osConfigMock2 = CreateOsConfigMockWithIsLinkedSetTo( true );
            var osCfgFactoryMock = Mock.Create<IOsConfigurationFactory>( Behavior.Strict );
            Mock.Arrange( () => osCfgFactoryMock.Get( Arg.IsAny<IApplicationInfo>(),
                this._osConfigInfos[0], Arg.IsAny<PathVariablesDTO>() ) )
                .Returns( Mock.Create<IOsConfigurationInt>() );
            Mock.Arrange( () => osCfgFactoryMock.Get( Arg.IsAny<IApplicationInfo>(),
                this._osConfigInfos[1], Arg.IsAny<PathVariablesDTO>() ) ).Returns( osConfigMock2 );
            this._osConfigFactoryMock = osCfgFactoryMock;
            this.InitializeTarget();

            var isLinked = this._target.IsLinked;

            Assert.IsTrue( isLinked );
        }



        private void Add2OsConfigInfosWithDistinctOsIds()
        {
            var osCfgInfo1 = Mock.Create<IOsConfigurationInfo>( Behavior.Strict );
            var randomOsId1 = RandomOsId();
            Mock.Arrange( () => osCfgInfo1.OsId ).Returns( randomOsId1 );
            this._osConfigInfos.Add( osCfgInfo1 );
            var osCfgInfo2 = Mock.Create<IOsConfigurationInfo>( Behavior.Strict );
            var randomOsId2 = RandomOsId( randomOsId1 );
            Mock.Arrange( () => osCfgInfo1.OsId ).Returns( randomOsId2 );
            this._osConfigInfos.Add( osCfgInfo2 );
        }


        private void AddOsConfigInfos( int amount )
        {
            for ( int i = 0 ; i < amount ; ++i )
            {
                var mock = Mock.Create<IOsConfigurationInfo>();
                this._osConfigInfos.Add( mock );
            }
        }


        private static IOsConfigurationFactory CreateOsCfgFactoryMockAlwaysReturning
            ( IOsConfiguration osConfigMock )
        {
            var osCfgFactoryMock = Mock.Create<IOsConfigurationFactory>( Behavior.Strict );
            Mock.Arrange( () => osCfgFactoryMock.Get( null, null, null ) ).IgnoreArguments()
                .Returns( osConfigMock );
            return osCfgFactoryMock;
        }


        private IOsConfigurationFactory CreateOsCfgFactoryMockFollowing
            ( IList<float> isLinkedRatioSequence )
        {
            var osCfgFactoryMock = Mock.Create<IOsConfigurationFactory>( Behavior.Strict );

            for ( int i = 0 ; i < isLinkedRatioSequence.Count ; ++i )
            {
                var osConfigIntMockNoI = Mock.Create<IOsConfigurationInt>( Behavior.Strict );
                var isLinkedRatio = isLinkedRatioSequence[i];
                Mock.Arrange( () => osConfigIntMockNoI.IsLinkedRatio ).Returns( isLinkedRatio );

                Mock.Arrange( () => osCfgFactoryMock.Get( Arg.IsAny<IApplicationInfo>(), 
                    this._osConfigInfos[i], Arg.IsAny<PathVariablesDTO>() ) ) 
                    .Returns( osConfigIntMockNoI );
            }

            return osCfgFactoryMock;
        }


        private IOsConfigurationFactory CreateOsCfgFactoryMockWhere2ndInfoReturns
            ( IOsConfiguration osConfigMock2 )
        {
            var osCfgFactoryMock = Mock.Create<IOsConfigurationFactory>( Behavior.Strict );

            Mock.Arrange( () => osCfgFactoryMock.Get( Arg.IsAny<IApplicationInfo>(),
                this._osConfigInfos[0], Arg.IsAny<PathVariablesDTO>() ) )
                .Returns( Mock.Create<IOsConfigurationInt>() );
            Mock.Arrange( () => osCfgFactoryMock.Get( Arg.IsAny<IApplicationInfo>(),
                this._osConfigInfos[1], Arg.IsAny<PathVariablesDTO>() ) ).Returns( osConfigMock2 );

            return osCfgFactoryMock;
        }


        private static IOsConfiguration CreateOsConfigMockWithIsInCloudSetTo( bool isInCloud )
        {
            var osConfigMock = Mock.Create<IOsConfigurationInt>( Behavior.Strict );
            Mock.Arrange( () => osConfigMock.IsInCloud ).Returns( isInCloud );
            return osConfigMock;
        }


        private static IOsConfiguration CreateOsConfigMockWithIsLinkedSetTo( bool isLinked )
        {
            var osConfigMock = Mock.Create<IOsConfigurationInt>( Behavior.Strict );
            Mock.Arrange( () => osConfigMock.IsLinked ).Returns( isLinked );
            return osConfigMock;
        }


        private void InitializeTarget()
        {
            var parametersDTO = new DefinitionParametersDTO
            {
                ApplicationInfo = this._appInfo, 
                OsConfigurationInfos = this._osConfigInfos, 
                PathVariablesDTO = null
            };
            var dependenciesDTO = new DefinitionDependenciesDTO
            {
                OsConfigurationFactory = this._osConfigFactoryMock, 
                OsFilter = this._osFilterMock
            };
            this._target = new Definition( parametersDTO, dependenciesDTO );
        }


        private static OsId RandomOsId( OsId? except = null )
        {
            OsId? randomOsId = null;

            var enumValues = Enum.GetValues( typeof( OsId ) ).OfType<OsId>().ToArray();
            randomOsId = XeRandom.RandomTFromArrayOf( enumValues );
            if ( except != null )
            {
                while ( randomOsId.Value == except.Value )
                {
                    randomOsId = XeRandom.RandomTFromArrayOf( enumValues );
                }
            }

            return randomOsId.Value;
        }


        private void ResetParameters()
        {
            this._target = null;
            this._appInfo = Mock.Create<IApplicationInfo>();
            this._osConfigFactoryMock = Mock.Create<IOsConfigurationFactory>( Behavior.Strict );
            this._osConfigInfos = new List<IOsConfigurationInfo>();
            this._osFilterMock = Mock.Create<IOsFilter>( Behavior.Strict );
        }



        private IApplicationInfo _appInfo;
        private IOsConfigurationFactory _osConfigFactoryMock;
        private IList<IOsConfigurationInfo> _osConfigInfos;
        private IOsFilter _osFilterMock;
        private IDefinition _target;
    }
}
